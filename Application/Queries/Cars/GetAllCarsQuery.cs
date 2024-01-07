using Application.DTO.Cars;
using MediatR;

namespace Application.Queries.Cars
{
    public class GetAllCarsQuery : IRequest<IEnumerable<CarDTO>> { }

        
}


