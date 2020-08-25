using MongoDB.Driver;
using Microsoft.Extensions.Options;
using SuperStudentDiscountApi.Models;
namespace SuperStudentDiscountApi.Mapper
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;
        public DbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<SuperStudentDiscountMongo> SuperStudentDiscounts
        {
            get
            {
                return _database.GetCollection<SuperStudentDiscountMongo>("superstudentdiscount");
            }
        }
    }

}