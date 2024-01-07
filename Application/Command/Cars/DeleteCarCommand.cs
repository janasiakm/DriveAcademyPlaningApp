using MediatR;

namespace Application.Command.Cars
{
    public class DeleteCarCommand : IRequest<int>
    {
        public int CarId { get; set; }

        public DeleteCarCommand(int carId)
        {
            CarId = carId;
        }
    }
}