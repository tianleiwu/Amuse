using System.Windows;

namespace Amuse.UI.Services
{
    public interface IDialogService
    {
        T GetDialog<T>() where T : Window;
        T GetDialog<T>(Window owner) where T : Window;
    }

}
