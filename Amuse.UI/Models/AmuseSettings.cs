using Microsoft.ML.OnnxRuntime;
using OnnxStack.Common.Config;
using OnnxStack.Core.Config;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        public IEnumerable<ExecutionProvider> SupportedExecutionProviders => GetFilteredItems();

        public ObservableCollection<ModelTemplateViewModel> Templates { get; set; } = new ObservableCollection<ModelTemplateViewModel>();
        public ObservableCollection<UpscaleModelSetViewModel> UpscaleModelSets { get; set; } = new ObservableCollection<UpscaleModelSetViewModel>();
        public ObservableCollection<StableDiffusionModelSetViewModel> StableDiffusionModelSets { get; set; } = new ObservableCollection<StableDiffusionModelSetViewModel>();

        public IEnumerable<ExecutionProvider> GetFilteredItems()
        {
#if DEBUG_DML || RELEASE_DML
            yield return ExecutionProvider.DirectML;
#elif DEBUG_CUDA || RELEASE_CUDA
            yield return ExecutionProvider.Cuda;
#elif DEBUG_TENSORRT || RELEASE_TENSORRT
            yield return ExecutionProvider.TensorRT;
#endif
            yield return ExecutionProvider.Cpu;
        }

        public void Initialize()
        {
            DefaultExecutionProvider = SupportedExecutionProviders.Contains(DefaultExecutionProvider)
                ? DefaultExecutionProvider
                : SupportedExecutionProviders.First();
        }

    }

    public enum ModelCacheMode
    {
        Single = 0,
        Multiple = 1
    }
}
