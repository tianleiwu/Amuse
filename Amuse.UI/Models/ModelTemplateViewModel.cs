using OnnxStack.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading;


namespace Amuse.UI.Models
{
    public class ModelTemplateViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _imageIcon;
        private string _author;
        private string _description;

        private bool _isInstalled;
        private bool _isDownloading;
        private double _progressValue;
        private string _progressText;
        private string _errorMessage;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        public string ImageIcon
        {
            get { return _imageIcon; }
            set { _imageIcon = value; NotifyPropertyChanged(); }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; NotifyPropertyChanged(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(); }
        }

        public int Rank { get; set; }
        public bool IsUserTemplate { get; set; }

        public string Template { get; set; }

        public ModelTemplateCategory Category { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UpscaleModelTemplate UpscaleTemplate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StableDiffusionModelTemplate StableDiffusionTemplate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Website { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Repository { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RepositoryBranch { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> RepositoryFiles { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> PreviewImages { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Tags { get; set; }

        [JsonIgnore]
        public string RepositoryClone
        {
            get
            {
                return string.IsNullOrEmpty(RepositoryBranch)
                ? Repository
                : $"{Repository} -b {RepositoryBranch}";
            }
        }

        [JsonIgnore]
        public bool IsInstalled
        {
            get { return _isInstalled; }
            set { _isInstalled = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public bool IsDownloading
        {
            get { return _isDownloading; }
            set { _isDownloading = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public double ProgressValue
        {
            get { return _progressValue; }
            set { _progressValue = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public string ProgressText
        {
            get { return _progressText; }
            set { _progressText = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public bool IsRepositoryCloneEnabled => !string.IsNullOrEmpty(Repository);

        [JsonIgnore]
        public bool IsRepositoryDownloadEnabled => !RepositoryFiles.IsNullOrEmpty();

        [JsonIgnore]
        public CancellationTokenSource CancellationTokenSource { get; set; }



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }



}
