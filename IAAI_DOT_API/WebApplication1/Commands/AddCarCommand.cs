using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using MediatR;
using IAAI_CAR.Services;
using IAAI_CAR.Models;
using IAAI_CAR.Events;

namespace IAAI_CAR.Commands
{
    public class AddCarCommand : IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }

        [BsonRequired]
        public string Make { get; set; }

        [BsonRequired]
        public string Model { get; set; }
        [BsonIgnoreIfNull]
        public int Year { get; set; } // Optional (defaults to 0 if not provided)
        [BsonIgnoreIfNull]
        public int Mileage { get; set; } // Optional (defaults to 0 if not provided)
        [BsonIgnoreIfNull]
        public string? Location { get; set; } // Optional (nullable)

        [BsonIgnoreIfNull]
        public DateTime? Auction_Date { get; set; } // Optional (nullable)
    }

    public class AddCarCommandHandler(CarService _carService, IMediator mediator) : IRequestHandler<AddCarCommand>
    {
  
        public async Task Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.CreateCarAsync(new TrnCarAuctionDetails
            {
                Id = request.Id,
                Make = request.Make,
                Model = request.Model,
                Year = request.Year,
                Mileage = request.Mileage,
                Location = request.Location,
                Auction_Date = request.Auction_Date
            });
            await mediator.Publish(new CarAddedEvent(request.Id, request.Make, request.Model, request.Auction_Date ?? DateTime.Now), cancellationToken);

        }
    }

}
