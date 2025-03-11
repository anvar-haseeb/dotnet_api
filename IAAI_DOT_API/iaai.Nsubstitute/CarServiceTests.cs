using System.Diagnostics;
using IAAI_CAR.Data;
using IAAI_CAR.Models;
using IAAI_CAR.Repositories;
using IAAI_CAR.Services;
using NSubstitute;

namespace iaai.Nsubstitute
{
    public class CarServiceTests
    {
        private readonly CarService _carService;
        private readonly ICarRepository _carRepositoryMock;

        public CarServiceTests() {

            _carRepositoryMock = Substitute.For<ICarRepository>();

            // Inject the mock into CarService
            _carService = new CarService(_carRepositoryMock);
        }

        [Fact]
        public void GetAllCars_ShouldReturnListOfCars()
        {
            // Arrange
            string carId = "677bcfcc90f7252e85afd120";
            var expectedCar = new TrnCarAuctionDetails
            {
                Id = carId,
                Make = "Nissan",
                Model = "Sentra",
                Year = 2016,
                Mileage = 129318,
                Location = "San Francisco",
                   Auction_Date = new DateTime(2024, 12, 22) 
            };
            var expectedCars = new List<TrnCarAuctionDetails> { expectedCar };
            _carRepositoryMock.GetAllCars().Returns(expectedCars);

            // Act
            var result = _carService.GetAllCars();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCar.Model, result[0].Model);

        }

        [Fact]
        public void GetCarByid_ShouldReturnTheCar()
        {
            // Arrange
            string carId = "677bcfcc90f7252e85afd120";
            var expectedCar = new TrnCarAuctionDetails
            {
                Id = carId,
                Make = "Nissan",
                Model = "Sentra",
                Year = 2016,
                Mileage = 129318,
                Location = "San Francisco",
                Auction_Date = new DateTime(2024, 12, 22)
            };
          
            _carRepositoryMock.GetCarById(carId).Returns(expectedCar);

            // Act
            var result = _carService.GetCarById(carId);

            // Assert

            Assert.NotNull(result);
            Assert.Equal(carId, result.Id);
            Assert.Equal(result, result);
        }

        [Theory]
        [InlineData("677bcfcc90f7252e85afd120", "Nissan", "Sentra", 2016, 129318, "San Francisco")]
        [InlineData("1234567890abcdef12345678", "Toyota", "Corolla", 2018, 50000, "New York")]
        public void GetCarById_ShouldReturnTheCar(string carId, string make, string model, int year, int mileage, string location)
        {
           
            // Arrange
            var expectedCar = new TrnCarAuctionDetails
            {
                Id = carId,
                Make = make,
                Model = model,
                Year = year,
                Mileage = mileage,
                Location = location,
                Auction_Date = new DateTime(2024, 12, 22)
            };

            _carRepositoryMock.GetCarById(carId).Returns(expectedCar);

            // Act
            var result = _carService.GetCarById(carId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(carId, result.Id);
            Assert.Equal(make, result.Make);
            Assert.Equal(model, result.Model);
        }

    }
}