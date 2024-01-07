using Application.DTO.Cars;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Cars
{
    public class GetCarByIdQuery : IRequest<CarFullDTO>
    {
        public int CarId { get; set; }

        public GetCarByIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}


