using MongoDB.Driver;
using Microsoft.Extensions.Options;
using IAAI_CAR.Models;

namespace IAAI_CAR.Data
{
    public class MongoDBContext 
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
           
        }
        public IMongoCollection<TrnCarAuctionDetails> CarAuctionDetails =>
              _database.GetCollection<TrnCarAuctionDetails>("trn-car-auction-details");

    }
}
