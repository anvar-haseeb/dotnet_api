using IAAI_CAR.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IAAI_CAR.Events

{
    public class CarAddedEventHandler(ILogger<AddCarCommandHandler> _logger) : INotificationHandler<CarAddedEvent>
    {
        public Task Handle(CarAddedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($" New Car Added: {notification.Make} {notification.Model}, Auction on {notification.AuctionDate}");
            _logger.LogInformation($" notification as CarAddedEvent :  {notification.Model}");
            return Task.CompletedTask;
        }
    }
}
