using CRUDify_UI.Interface;
using CRUDify_UI.Model;
using System.Windows;
using System.Windows.Controls;

namespace CRUDify_UI.View
{
    /// <summary>
    /// Interaction logic for UpdateDocumentView.xaml
    /// </summary>
    public partial class UpdateDocumentView : UserControl
    {
        public UpdateDocumentView()
        {
            InitializeComponent();
        }

        private void CloseWindow_OnClickingApply(object sender, RoutedEventArgs e)
        {
            IDialogService dialogService = new UserControlContainerDialog();
            dialogService.CloseDialog(this);
        }
    }   
}
