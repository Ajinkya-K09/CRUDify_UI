using CRUDify_UI.DatabaseServices;
using MongoDB.Bson;

namespace CRUDify_UI
{
    public class BsonDocumentConverter
    {
        public BsonDocument GenerateBsonDoc(DatabaseFieldsMapper documentModel)
        {
            BsonDocument bson = BsonExtensionMethods.ToBsonDocument(documentModel);
            return bson;
        }

        public BsonDocument RemoveField(BsonDocument bsonDoc, string fieldName)
        {
            bsonDoc.Remove(fieldName);
            return bsonDoc;
        }
    }
}