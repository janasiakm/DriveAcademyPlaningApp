using Application.DTO.Cars;
using MediatR;


namespace Application.Command.Cars
{
    public class UpdateCarCommand : IRequest<int>
    {
        public int CarId { get; set; }
        public string Mark { get; set; } = "";
        public string Model { get; set; } = "";
        public string RejestractionNumber { get; set; } = "";
        public int ProductionYear { get; set; }


        public UpdateCarCommand(CarFullDTO car)
        {
            CarId = car.CarId;
            Mark = car.Mark;
            Model = car.Model;
            RejestractionNumber = car.RejestractionNumber;
            ProductionYear = car.ProductionYear;
        }
    }
}