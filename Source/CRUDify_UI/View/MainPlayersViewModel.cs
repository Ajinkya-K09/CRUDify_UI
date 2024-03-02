using System.Collections.ObjectModel;

namespace CRUDify_UI
{
    class MainPlayersViewModel
    {
        public MainPlayersViewModel()
        {
            var module = new MainPlayersModule();
            module.LastName = "CR7";
            MainVM = module;

            ListOfPlayers = new ObservableCollection<MainPlayersModule>()
            {
                new MainPlayersModule() {FirstName = "Ajinkya", LastName = "Kulkarni", Age = 25, IsActive= true},
                new MainPlayersModule() {FirstName = "Prathamesh", LastName = "Vaiday", Age = 24, IsActive= true},
                new MainPlayersModule() {FirstName = "Ravi", LastName = "Kumar", Age = 22, IsActive= true},
                new MainPlayersModule() {FirstName = "Leo", LastName = "Messi", Age = 21, IsActive= true},
                new MainPlayersModule() {FirstName = "Cristinao", LastName = "Ronaldo", Age = 15, IsActive= true}
            };
        }

        public string FirstName { get; set; }

        public MainPlayersModule MainVM { get; set; }

        public ObservableCollection<MainPlayersModule> ListOfPlayers { get; private set; }
    }
}
