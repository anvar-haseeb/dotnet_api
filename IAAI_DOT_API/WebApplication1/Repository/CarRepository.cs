using IAAI_CAR.Models;
using IAAI_CAR.Data;
using MongoDB.Driver;

namespace IAAI_CAR.Repositories
{
    public interface ICarRepository
    {
        List<TrnCarAuctionDetails> GetAllCars();
        TrnCarAuctionDetails? GetCarById(string id);
        Task<bool> CreateCarAsync(TrnCarAuctionDetails car);
        Task<bool> DeleteCarAsync(string id);
        Task<bool> UpdateCarAsync(string id, TrnCarAuctionDetails car);
    }

    public class CarRepository : ICarRepository
    {
        private readonly MongoDBContext _mongoContext;

        public CarRepository(MongoDBContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public List<TrnCarAuctionDetails> GetAllCars()
        {
            return _mongoContext.CarAuctionDetails.Find(car => true).ToList();
        }

        public TrnCarAuctionDetails? GetCarById(string id)
        {
            return _mongoContext.CarAuctionDetails.Find(car => car.Id == id).FirstOrDefault();
        }

        public async Task<bool> CreateCarAsync(TrnCarAuctionDetails car)
        {
            try
            {
                await _mongoContext.CarAuctionDetails.InsertOneAsync(car);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCarAsync(string id)
        {
            var result = await _mongoContext.CarAuctionDetails.DeleteOneAsync(car => car.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<bool> UpdateCarAsync(string id, TrnCarAuctionDetails car)
        {
            car.Id = id;
            var result = await _mongoContext.CarAuctionDetails.ReplaceOneAsync(c => c.Id == id, car);
            return result.ModifiedCount > 0;
        }
    }
}
