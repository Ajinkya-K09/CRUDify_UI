using MongoDB.Bson;

namespace CRUDify_UI
{
    internal class CRUDify_UIModel
    {
        public BsonObjectId RecordId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public string Nation { get; set; }

        public string Position { get; set; }

        public string Club { get; set; }
    }
}