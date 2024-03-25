using CRUDify_UI.Interface;
using CRUDify_UI.Model;
using CRUDify_UI.View;
using DbConnector;
using MongoDB.Bson;
using MongoDB.Driver;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace CRUDify_UI
{
    class CRUDify_UIViewModel : BindableBase
    {
        private CRUDify_UIModel m_currentSelectedRecord;
        public CRUDify_UIViewModel()
        {
            ListOfPlayers = new ObservableCollection<CRUDify_UIModel>();

            DatabaseConnection = new DatabaseConnection();

            RetriveButton = new DelegateCommand(HandleRetriveCommand);

            UpdateButton = new DelegateCommand(UpdateHandler);

            DeleteButton = new DelegateCommand<CRUDify_UIModel>(HandleDeleteCommand);
        }

        public ObservableCollection<CRUDify_UIModel> ListOfPlayers { get; private set; }

        public ICommand RetriveButton { get; set; }

        public DelegateCommand<CRUDify_UIModel> DeleteButton { get; set; }

        public DelegateCommand UpdateButton { get; set; }

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
                if (SelectedRecord != null)
                {
                    StoredSelectedRecordId = SelectedRecord.RecordId;
                }

                if (SelectedRecord == null)
                {
                    StoredSelectedRecordId = null;
                }
                RaisePropertyChanged(nameof(SelectedRecord));
            }
        }

        public static BsonObjectId? StoredSelectedRecordId { get; private set; }

        private void UpdateHandler()
        {
            var currentUserControl = new UpdateDocumentView();
            IDialogService dialogService = new UserControlContainerDialog();
            dialogService.ShowDialog(currentUserControl);
            HandleRetriveCommand();
        }

        private void HandleDeleteCommand(CRUDify_UIModel selectedItem)
        {
            DatabaseConnection.FootballCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", selectedItem.RecordId));
            HandleRetriveCommand();
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

    }
}
