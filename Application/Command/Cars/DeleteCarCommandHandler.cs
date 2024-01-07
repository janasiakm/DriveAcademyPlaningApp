using Application.Interfaces;
using MediatR;

namespace Application.Command.Cars
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, int>
    {
        private readonly ICarService _carService;

        public DeleteCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<int> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            return await _carService.DeleteCar(request, cancellationToken);
        }
    }
}