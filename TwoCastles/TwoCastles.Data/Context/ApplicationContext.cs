using MongoDB.Driver;
using TwoCastles.Data.Constants;

namespace TwoCastles.Data.Context
{
    public class ApplicationContext
    {
        public ApplicationContext(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(ConstantsList.mongodbName);

            Database = database;
        }

        public IMongoDatabase Database { get; }
    }
}
