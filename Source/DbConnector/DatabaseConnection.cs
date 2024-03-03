using MongoDB.Bson;
using MongoDB.Driver;

namespace DbConnector
{
    public class DatabaseConnection
    {
        public static void Main(string[] args)
        {
            //var connection = new DatabaseConnection();
        }

        public DatabaseConnection()
        {
            string connectionUri = "connection_string";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            var client = new MongoClient(settings);

            // Send a ping to confirm a successful connection
            try
            {
                var result = client.GetDatabase("SQLAuthority").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
                var collection = client.GetDatabase("SQLAuthority").GetCollection<BsonDocument>("footballers");
                var filterQuery = Builders<BsonDocument>.Filter.Eq("SportsName", "Football");
                var doc = collection.Find(filterQuery).FirstOrDefault();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
