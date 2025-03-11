using System.Runtime.CompilerServices;
using IAAI_CAR.Data;
using IAAI_CAR.Services;
using IAAI_CAR.Repositories;
using Mongo2Go;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using IAAI_CAR.Models;
using MongoDB.Bson;


namespace iaai.Mongo2Go
{
    public class CarServicesTestMongo  : IDisposable  //to call dispose
    {
        private readonly MongoDbRunner _mongoRunner;
        private readonly MongoDBContext _mongoContext;
        private readonly CarRepository _carRepository;
        private readonly CarService _carService;

        public CarServicesTestMongo()
        {
            // Start an in-memory MongoDB instance
            _mongoRunner = MongoDbRunner.Start();

            var settings = Options.Create(new MongoDBSettings
            {
                ConnectionString = _mongoRunner.ConnectionString,
                DatabaseName = "TestCarDB"
            });

            Console.WriteLine($"MongoDB is running at: {_mongoRunner.ConnectionString}");


            // Initialize MongoDBContext with mocked settings
            _mongoContext = new MongoDBContext(settings);
          
            _carRepository = new CarRepository(_mongoContext);
            _carService = new CarService(_carRepository);
        }

        [Fact]
        public async Task CreateCarAsync_ShouldAddCarToDatabase()
        {
            var car = new TrnCarAuctionDetails
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Make = "Toyota",
                Model = "Corolla",
                Year = 2020,
                Mileage = 50000,
                Location = "New York",
                Auction_Date = DateTime.UtcNow
            };
            var result = await _carService.CreateCarAsync(car);
            var retrievedCar = _carService.GetCarById(car.Id);

            Console.WriteLine($"retrievedCar: {retrievedCar}");
            Console.WriteLine($"result: {result}");


            Assert.True(result);
            Assert.NotNull(retrievedCar);
            Assert.Equal("Toyota", retrievedCar.Make);
        }

        [Fact]
        public async Task CreateCarAsync_MissingRequiredFields_ShouldThrowException()
        {
            var car = new TrnCarAuctionDetails
            {
                Id = null, // Use a valid ObjectId
                Make = "Toyota",
                Model = "Corolla",
                Year = 2020,
                Mileage = 50000,
                Location = "New York",
                Auction_Date = DateTime.UtcNow
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
            _carService.CreateCarAsync(car)
            );
        }

        [Theory]
        [InlineData(null)]
        public async Task createCarAsync_MissingMake_ThrowExceprion(String make)
        {
            var car = new TrnCarAuctionDetails
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Make = make,
                Model = "Corolla",
                Year = 2020,
                Mileage = 50000,
                Location = "New York",
                Auction_Date = DateTime.UtcNow

            };
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
            _carService.CreateCarAsync(car)

            );
        }

        public void Dispose()
        {
             Console.WriteLine("Disposing Mongo2Go instance...");
            _mongoRunner.Dispose();
        }

    }
}