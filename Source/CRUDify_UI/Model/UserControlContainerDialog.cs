using CRUDify_UI.Interface;
using CRUDify_UI.View;
using System.Windows;
using System.Windows.Controls;

namespace CRUDify_UI.Model
{
    public class UserControlContainerDialog : IDialogService
    {
        public void ShowDialog(UserControl userControl)
        {
            UserControlContainer dialogwindow = new UserControlContainer();
            dialogwindow.Content = userControl;
            dialogwindow.ShowDialog();
        }

        public void CloseDialog(UserControl userControl)
        {
            Window parentWindow = Window.GetWindow(userControl);
            parentWindow.Close();
        }
    }
}