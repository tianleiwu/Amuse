using Amuse.UI.Models;
using System.Threading.Tasks;

namespace Amuse.UI.Views
{
    public interface INavigatable
    {
        Task NavigateAsync(ImageResult imageResult);
    }
}
