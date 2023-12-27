using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Amuse.UI.UserControls
{
    public class CachedImage : Image
    {
        private static ConcurrentDictionary<string, BitmapImage> _imageCache = new ConcurrentDictionary<string, BitmapImage>();

        static CachedImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CachedImage), new FrameworkPropertyMetadata(typeof(CachedImage)));
        }

        public string CacheName
        {
            get { return (string)GetValue(CacheNameProperty); }
            set { SetValue(CacheNameProperty, value); }
        }
        public static readonly DependencyProperty CacheNameProperty = DependencyProperty.Register("CacheName", typeof(string), typeof(CachedImage));

        public int CacheWidth
        {
            get { return (int)GetValue(CacheWidthProperty); }
            set { SetValue(CacheWidthProperty, value); }
        }
        public static readonly DependencyProperty CacheWidthProperty = DependencyProperty.Register("CacheWidth", typeof(int), typeof(CachedImage), new PropertyMetadata(256));


        public bool IsLazyCache
        {
            get { return (bool)GetValue(IsLazyCacheProperty); }
            set { SetValue(IsLazyCacheProperty, value); }
        }
        public static readonly DependencyProperty IsLazyCacheProperty = DependencyProperty.Register("IsLazyCache", typeof(bool), typeof(CachedImage), new PropertyMetadata(false));


        public BitmapSource Placeholder
        {
            get { return (BitmapSource)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        public static readonly DependencyProperty PlaceholderProperty =
                DependencyProperty.Register("Placeholder", typeof(BitmapSource), typeof(CachedImage), new PropertyMetadata(async (s, e) =>
                {
                    if (s is CachedImage cachedImage && cachedImage.Source is null)
                        await cachedImage.GetOrDownloadImage(cachedImage.ImageUrl);
                }));

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }
        public static readonly DependencyProperty ImageUrlProperty =
                DependencyProperty.Register("ImageUrl", typeof(string), typeof(CachedImage), new PropertyMetadata(async (s, e) =>
                {
                    if (s is CachedImage cachedImage)
                        await cachedImage.GetOrDownloadImage(e.NewValue as string);
                }));


        /// <summary>
        /// Gets or downloads the image.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        public async Task GetOrDownloadImage(string imageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    Source = Placeholder;
                    return;
                }

                var cacheName = CacheName;
                var cacheWidth = CacheWidth;
                var filename = Path.GetFileName(imageUrl);
                var directory = Utils.GetImageCacheDirectory(CacheName ?? ".default", true);
                var existingImage = Path.Combine(directory, filename);
                if(File.Exists(existingImage))
                {
                    Source = await LoadImage(existingImage, cacheWidth);
                    return;
                }

                if (IsLazyCache)
                {
                    if (_imageCache.TryGetValue(existingImage, out var cachedImage))
                    {
                        Source = Placeholder;
                        return;
                    }

                    if (_imageCache.TryAdd(existingImage, default))
                    {
                       
                        var image = await DownloadImage(imageUrl, existingImage, cacheWidth);
                        _imageCache.TryUpdate(existingImage, image, default);
                        if(imageUrl == ImageUrl)
                        {
                            Source = image;
                        }
                    }
                }
                else
                {
                    Source = await DownloadImage(imageUrl, existingImage, CacheWidth);
                }
            }
            catch (Exception)
            {
                Source = Placeholder;
            }
        }


        /// <summary>
        /// Loads the image from the cahe directory.
        /// </summary>
        /// <param name="imageFile">The image file.</param>
        private static async Task<BitmapImage> LoadImage(string imageFile, int decodePixelWidth)
        {
            var tcs = new TaskCompletionSource<BitmapImage>();
            try
            {
                if (_imageCache.TryGetValue(imageFile, out var bitmapImage))
                    return bitmapImage;

                using (var fileStream = new FileStream(imageFile, FileMode.Open, FileAccess.Read))
                {
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = fileStream;
                    bitmapImage.DecodePixelWidth = decodePixelWidth;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    _imageCache.TryAdd(imageFile, bitmapImage);
                    tcs.SetResult(bitmapImage);
                }
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return await tcs.Task;
        }


        /// <summary>
        /// Downloads the image and saves it to the cache directory.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        private static async Task<BitmapImage> DownloadImage(string source, string destination, int decodePixelWidth)
        {
            var bitmapImage = new BitmapImage();
            using (var httpClient = new HttpClient())
            using (var imageStream = new MemoryStream(await httpClient.GetByteArrayAsync(source)))
            {
                var imagebytes = await httpClient.GetByteArrayAsync(source);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = imageStream;
                bitmapImage.DecodePixelWidth = decodePixelWidth;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                Directory.CreateDirectory(Path.GetDirectoryName(destination));
                using (var fileStream = new FileStream(destination, FileMode.CreateNew))
                {
                    encoder.Save(fileStream);
                }
                return bitmapImage;
            }
        }
    }

}
