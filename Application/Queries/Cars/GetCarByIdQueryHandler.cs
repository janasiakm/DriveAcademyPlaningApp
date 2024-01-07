using Application.DTO.Cars;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Cars
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarFullDTO>
    {
        private readonly ICarService _carService;

        public GetCarByIdQueryHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<CarFullDTO> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            return await _carService.GetCarById(request.CarId);
        }
    }
}