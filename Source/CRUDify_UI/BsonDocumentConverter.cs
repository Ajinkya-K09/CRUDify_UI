using CRUDify_UI.DatabaseServices;
using CRUDify_UI.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
