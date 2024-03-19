using CRUDify_UI.DatabaseServices;
using CRUDify_UI.Model;
using DbConnector;
using Prism.Commands;
using System.Windows.Input;

namespace CRUDify_UI.ViewModel
{
    public class UpdateDocumentViewModel
    {
        public UpdateDocumentViewModel()
        {
            ModelObj = new UpdateDocumentModel();
            ApplyCommand = new DelegateCommand(ApplyBtnHandler);
        }

        public ICommand ApplyCommand { get; set; }

        public UpdateDocumentModel ModelObj { get; set; }

        private void ApplyBtnHandler()
        {
            var dbFieldMapperObj = new DatabaseFieldsMapper(ModelObj);
            var bsonDocConverter = new BsonDocumentConverter();
            var bsonDoc = bsonDocConverter.GenerateBsonDoc(dbFieldMapperObj);

            var dbConnection = new DatabaseConnection();
            dbConnection.FootballCollection.InsertOneAsync(bsonDoc);
        }
    }
}
