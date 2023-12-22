using Amuse.UI.Models;
using OnnxStack.StableDiffusion.Config;

namespace Amuse.UI.Services
{
    public interface IModelFactory
    {
        UpscaleModelSet CreateUpscaleModelSet(string name, string filename, string modelTemplateType);
        UpscaleModelSet CreateUpscaleModelSet(string name, string filename, UpscaleModelTemplate modelTemplate);
        StableDiffusionModelSet CreateStableDiffusionModelSet(string name, string folder, string modelTemplateType);
        StableDiffusionModelSet CreateStableDiffusionModelSet(string name, string folder, StableDiffusionModelTemplate modelTemplate);
    }
}