using Application.DTO.Cars;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Cars
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarDTO>>
    {
        private readonly ICarService _carService;

        public GetAllCarsQueryHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IEnumerable<CarDTO>> Handle(GetAllCarsQuery request,CancellationToken cancellationToken)
        { 
            var result = await _carService.GetAllCars();
            return result; 
        }
    }
    
}   