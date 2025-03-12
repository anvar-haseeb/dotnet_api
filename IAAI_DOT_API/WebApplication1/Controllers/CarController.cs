using IAAI_CAR.Commands;
using IAAI_CAR.Models;
using IAAI_CAR.Services;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace IAAI_CAR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;
        private readonly IMediator _mediator;
        public CarController(CarService carService, IMediator mediator)
        {
            _carService = carService;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(string id)
        {
            var car = _carService.GetCarById(id);
            return car != null ? Ok(car) : NotFound("Car not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(TrnCarAuctionDetails car)
        {
            var command = new AddCarCommand
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Auction_Date = car.Auction_Date,
            };
            _mediator.Send(command);
            //var success = await _carService.CreateCarAsync(car);
            //return success ? Ok(car) : BadRequest("Failed to create car.");
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            var success = await _carService.DeleteCarAsync(id);
            return success ? Ok($"Deleted car with ID: {id}") : NotFound("Car not found.");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateCar(string id, TrnCarAuctionDetails car)
        {
            var success = await _carService.UpdateCarAsync(id, car);
            return success ? Ok(car) : BadRequest("Car details could not be updated.");
        }
    }
}
