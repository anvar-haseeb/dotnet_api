using IAAI_CAR.Models;
using IAAI_CAR.Data;
using MongoDB.Driver;
using IAAI_CAR.Repositories;
using MongoDB.Bson;

namespace IAAI_CAR.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<TrnCarAuctionDetails> GetAllCars()
        {
            return _carRepository.GetAllCars().Where(car=>car.Mileage>50000).ToList();
        }

        public TrnCarAuctionDetails? GetCarById(string id)
        {
            return _carRepository.GetCarById(id);
        }

        public async Task<bool> CreateCarAsync(TrnCarAuctionDetails car)
        {
            if (string.IsNullOrWhiteSpace(car.Make))
                throw new ArgumentNullException(nameof(car.Make), "Make is required.");

            if (string.IsNullOrWhiteSpace(car.Model))
                throw new ArgumentNullException(nameof(car.Model), "Model is required.");

            if (string.IsNullOrWhiteSpace(car.Id))
                throw new ArgumentNullException(nameof(car.Id), "Id is required.");

            return await _carRepository.CreateCarAsync(car);
        }

        public async Task<bool> DeleteCarAsync(string id)
        {
            return await _carRepository.DeleteCarAsync(id);
        }

        public async Task<bool> UpdateCarAsync(string id, TrnCarAuctionDetails car)
        {
            return await _carRepository.UpdateCarAsync(id, car);
        }
    }
}
