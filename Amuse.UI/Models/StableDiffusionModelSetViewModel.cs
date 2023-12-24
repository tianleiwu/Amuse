using OnnxStack.StableDiffusion.Config;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Amuse.UI.Models
{
    public class StableDiffusionModelSetViewModel : INotifyPropertyChanged
    {
        private string _name;
        private bool _isLoaded;
        private bool _isLoading;
        private StableDiffusionModelSet _modelSet;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; NotifyPropertyChanged(); }
        }

        [JsonIgnore]
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; NotifyPropertyChanged(); }
        }

        public StableDiffusionModelSet ModelSet
        {
            get { return _modelSet; }
            set { _modelSet = value; NotifyPropertyChanged(); }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
