using System.Windows.Media.Imaging;

namespace Amuse.UI.Models
{
    public record UpscaleResult(BitmapSource Image, UpscaleInfoModel Info, double Elapsed);
}
