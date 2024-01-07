
using Application.DTO.Cars;
using MediatR;

namespace Application.Command.Cars
{
    public class CreateCarCommand : IRequest<int>
    {
        public string Mark { get; set; } = "";
        public string Model { get; set; } = "";
        public string RejestractionNumber { get; set; } = "";
        public int ProductionYear { get; set; }


        public CreateCarCommand(CarFullDTO car)
        {
            Mark = car.Mark;
            Model = car.Model;
            RejestractionNumber = car.RejestractionNumber;
            ProductionYear = car.ProductionYear;
        }
    }
}
