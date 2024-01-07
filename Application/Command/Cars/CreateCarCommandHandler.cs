using Application.Interfaces;
using MediatR;

namespace Application.Command.Cars
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            return await _carService.AddCar(request, cancellationToken);
        }
    }
}