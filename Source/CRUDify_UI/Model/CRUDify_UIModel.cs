using CRUDify_UI;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CRUDify_UI
{
    class CRUDify_UIModel
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
