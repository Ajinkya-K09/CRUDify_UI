using System.Windows.Controls;

namespace CRUDify_UI.Interface
{
    public interface IDialogService
    {
        void ShowDialog(UserControl userControl);

        void CloseDialog(UserControl userControl);
    }
}