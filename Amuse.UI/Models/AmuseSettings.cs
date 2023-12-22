using Amuse.UI.Views;
using Microsoft.ML.OnnxRuntime;
using OnnxStack.Common.Config;
using OnnxStack.Core.Config;
using System.Collections.ObjectModel;

namespace Amuse.UI.Models
{
    public class AmuseSettings : IConfigSection
    {
        public ModelCacheMode ModelCacheMode { get; set; }

        public bool ImageAutoSave { get; set; }
        public bool ImageAutoSaveBlueprint { get; set; }
        public string ImageAutoSaveDirectory { get; set; }
        public int RealtimeRefreshRate { get; set; } = 100;
        public bool RealtimeHistoryEnabled { get; set; }
        public int DefaultDeviceId { get; set; }
        public int DefaultInterOpNumThreads { get; set; }
        public int DefaultIntraOpNumThreads { get; set; }
        public ExecutionMode DefaultExecutionMode { get; set; }
        public ExecutionProvider DefaultExecutionProvider { get; set; }

        public ObservableCollection<ModelTemplateViewModel> Templates { get; set; } = new ObservableCollection<ModelTemplateViewModel>();
        public ObservableCollection<UpscaleModelSetViewModel> UpscaleModelSets { get; set; } = new ObservableCollection<UpscaleModelSetViewModel>();
        public ObservableCollection<StableDiffusionModelSetViewModel> StableDiffusionModelSets { get; set; } = new ObservableCollection<StableDiffusionModelSetViewModel>();

        public void Initialize()
        {
        }

    }

    public enum ModelCacheMode
    {
        Single = 0,
        Multiple = 1
    }
}
