using IAAI_CAR.Models;
using IAAI_CAR.Services;
using MediatR;

namespace IAAI_CAR.Queries
{
    public class GetAllCarsQuery : IRequest<List<TrnCarAuctionDetails>>
    {
        // no req params   
    }
    public class GetCarByIdQuery(CarService _carService) : IRequestHandler<GetAllCarsQuery, List<TrnCarAuctionDetails>>
    {

        public async Task<List<TrnCarAuctionDetails>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            return _carService.GetAllCars();
        }
    }
    }
