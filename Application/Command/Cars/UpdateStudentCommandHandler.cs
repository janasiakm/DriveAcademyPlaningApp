using Application.Interfaces;
using MediatR;

namespace Application.Command.Cars
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, int>
    {
        private readonly ICarService _carService;

        public UpdateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<int> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            return await _carService.UpdateCar(request, cancellationToken);
        }
    }
}