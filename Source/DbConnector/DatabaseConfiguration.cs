using MongoDB.Bson;
using MongoDB.Driver;

namespace DbConnector
{
    public class DatabaseConfiguration
    {
        public static void Main(string[] args)
        {
            //var connection = new DatabaseConnection();
        }

        public DatabaseConfiguration()
        {
            string connectionUri = string.Empty;
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
                FootballCollection = client.GetDatabase("SQLAuthority").GetCollection<BsonDocument>("footballers");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public IMongoCollection<BsonDocument> FootballCollection { get; set; }

    }
}
