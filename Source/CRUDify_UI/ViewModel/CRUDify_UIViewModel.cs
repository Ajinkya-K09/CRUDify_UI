using System.Collections.ObjectModel;

namespace CRUDify_UI
{
    class CRUDify_UIViewModel
    {
        public CRUDify_UIViewModel()
        {
            var module = new CRUDify_UIModel();
            module.LastName = "CR7";
            MainVM = module;

            ListOfPlayers = new ObservableCollection<CRUDify_UIModel>()
            {
                new CRUDify_UIModel() {FirstName = "Ajinkya", LastName = "Kulkarni", Age = 25, IsActive= true},
                new CRUDify_UIModel() {FirstName = "Prathamesh", LastName = "Vaiday", Age = 24, IsActive= true},
                new CRUDify_UIModel() {FirstName = "Ravi", LastName = "Kumar", Age = 22, IsActive= true},
                new CRUDify_UIModel() {FirstName = "Leo", LastName = "Messi", Age = 21, IsActive= true},
                new CRUDify_UIModel() {FirstName = "Cristinao", LastName = "Ronaldo", Age = 15, IsActive= true}
            };
        }

        public string FirstName { get; set; }

        public CRUDify_UIModel MainVM { get; set; }

        public ObservableCollection<CRUDify_UIModel> ListOfPlayers { get; private set; }
    }
}
