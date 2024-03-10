using DbConnector;
using MongoDB.Bson;
using MongoDB.Driver;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                new CRUDify_UIModel { FullName = "Ajinkya Kulkarni", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

                new CRUDify_UIModel { FullName = "Ajinkya Kulkarni", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

                new CRUDify_UIModel { FullName = "Ajinkya Kulkarnifdgdfgdsfgdsfg", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

                new CRUDify_UIModel { FullName = "Ajinkya Kulkarnifdgdfgdsfgdsfg", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

                new CRUDify_UIModel { FullName = "Ajinkya Kulkarnifdgdfgdsfgdsfg", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },
        };

            //ListOfPlayers = new ObservableCollection<CRUDify_UIModel>();

            //DatabaseConnection = new DatabaseConnection();

            RetriveButton = new DelegateCommand(HandleRetriveCommand);
        }

        private void HandleRetriveCommand()
        {
            var documentListInCollection = DatabaseConnection.FootballCollection.Aggregate().ToListAsync().Result;

            ListOfPlayers.Clear();

            AddBsonDocDataToView(documentListInCollection);
        }

        private void AddBsonDocDataToView(List<BsonDocument> documentListInCollection)
        {
            foreach (var item in documentListInCollection)
            {
                var bsonDoc = item.ToBsonDocument();
                var data = Tuple.Create(bsonDoc["FullName"].AsString, bsonDoc["PlayingNation"].AsString, bsonDoc["Position"].AsString,
                    bsonDoc["Club"].AsString, bsonDoc["IsActivePlayer"].AsBoolean);

                var model = new CRUDify_UIModel() { FullName = data.Item1, Nation = data.Item2, Position = data.Item3, Club = data.Item4, IsActive = data.Item5 };

                ListOfPlayers.Add(model);
            }
        }

        public string FirstName { get; set; }

        public CRUDify_UIModel MainVM { get; set; }

        public ObservableCollection<CRUDify_UIModel> ListOfPlayers { get; private set; }

        public ICommand RetriveButton { get; set; }

        public DatabaseConnection DatabaseConnection { get; set; }

    }
}
