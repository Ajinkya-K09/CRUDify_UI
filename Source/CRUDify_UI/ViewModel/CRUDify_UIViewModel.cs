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
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDify_UI
{
    internal class CRUDify_UIViewModel : BindableBase
    {
        private CRUDify_UIModel m_currentSelectedRecord;

        public CRUDify_UIViewModel()
        {
            ListOfPlayers = new ObservableCollection<CRUDify_UIModel>();

            RetriveButton = new DelegateCommand(HandleRetriveCommand);

            UpdateButton = new DelegateCommand(UpdateHandler);

            DeleteButton = new DelegateCommand<CRUDify_UIModel>(HandleDeleteCommand, CanDelete);
        }

        public ObservableCollection<CRUDify_UIModel> ListOfPlayers { get; private set; }

        public ICommand RetriveButton { get; set; }

        public DelegateCommand<CRUDify_UIModel> DeleteButton { get; set; }

        public DelegateCommand UpdateButton { get; set; }

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
                DeleteButton.RaiseCanExecuteChanged();
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

        private bool CanDelete(CRUDify_UIModel selectedItem)
        {
            if (selectedItem != null)
            {
                return true;
            }

            return false;
        }

        private void HandleDeleteCommand(CRUDify_UIModel selectedItem)
        {
            DatabaseConnector.DbConnectorInstance.FootballCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", selectedItem.RecordId));
            HandleRetriveCommand();
        }

        private async void HandleRetriveCommand()
        {
            var aggregate = DatabaseConnector.DbConnectorInstance.FootballCollection.Aggregate();
            var documentListInCollection = await aggregate.ToListAsync();

            ListOfPlayers.Clear();

            await AddBsonDocDataToView(documentListInCollection);
        }

        private async Task AddBsonDocDataToView(List<BsonDocument> documentListInCollection)
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