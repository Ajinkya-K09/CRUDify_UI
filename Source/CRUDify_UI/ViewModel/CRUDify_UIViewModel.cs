using DbConnector;
using MongoDB.Bson;
using MongoDB.Driver;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CRUDify_UI
{
    class CRUDify_UIViewModel : BindableBase
    {
        private CRUDify_UIModel m_currentSelectedRecord;

        public CRUDify_UIViewModel()
        {
            //    ListOfPlayers = new ObservableCollection<CRUDify_UIModel>()
            //    {
            //        new CRUDify_UIModel { FullName = "Ajinkya Kulkarni", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

            //        new CRUDify_UIModel { FullName = "Ajinkya Kulkarni", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

            //        new CRUDify_UIModel { FullName = "Ajinkya Kulkarnifdgdfgdsfgdsfg", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

            //        new CRUDify_UIModel { FullName = "Ajinkya Kulkarnifdgdfgdsfgdsfg", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },

            //        new CRUDify_UIModel { FullName = "Ajinkya Kulkarnifdgdfgdsfgdsfg", Nation = "India", Position = "Fwd", Club = "Bharat", IsActive = true },
            //};

            ListOfPlayers = new ObservableCollection<CRUDify_UIModel>();

            DatabaseConnection = new DatabaseConnection();

            RetriveButton = new DelegateCommand(HandleRetriveCommand);

            DeleteButton = new DelegateCommand<CRUDify_UIModel>(HandleDeleteCommand);
        }

        private void HandleDeleteCommand(CRUDify_UIModel selectedItem)
        {
            DatabaseConnection.FootballCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", selectedItem.RecordId));
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
                var data = Tuple.Create(bsonDoc["_id"].AsObjectId, bsonDoc["FullName"].AsString, bsonDoc["PlayingNation"].AsString, bsonDoc["Position"].AsString,
                    bsonDoc["Club"].AsString, bsonDoc["IsActivePlayer"].AsBoolean);

                var model = new CRUDify_UIModel() { RecordId = data.Item1, FullName = data.Item2, Nation = data.Item3, Position = data.Item4, Club = data.Item5, IsActive = data.Item6 };

                ListOfPlayers.Add(model);
            }
        }


        public ObservableCollection<CRUDify_UIModel> ListOfPlayers { get; private set; }

        public ICommand RetriveButton { get; set; }

        public DelegateCommand<CRUDify_UIModel> DeleteButton { get;  set; }

        public DatabaseConnection DatabaseConnection { get; set; }

        public CRUDify_UIModel SelectedRecord
        {
            get
            {
                return m_currentSelectedRecord;
            }
            set
            {
                m_currentSelectedRecord = value;
                RaisePropertyChanged(nameof(SelectedRecord));  
            }
        }

    }
}
