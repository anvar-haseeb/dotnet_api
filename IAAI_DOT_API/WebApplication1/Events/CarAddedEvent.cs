using MediatR;

namespace IAAI_CAR.Events
{
    public class CarAddedEvent : INotification
    {
        public string CarId { get; }
        public string Make { get; }
        public string Model { get; }
        public DateTime AuctionDate { get; }

        public CarAddedEvent(string carId, string make, string model, DateTime auctionDate)
        {
            CarId = carId;
            Make = make;
            Model = model;
            AuctionDate = auctionDate;
        }
    }
}
