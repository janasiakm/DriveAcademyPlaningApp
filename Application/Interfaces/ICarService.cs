using Application.Command.Cars;
using Application.DTO.Cars;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllCars();
        Task<CarFullDTO> GetCarById(int carId);
        Task<int> AddCar(CreateCarCommand body, CancellationToken cancellationToken);
        Task<int> UpdateCar(UpdateCarCommand body, CancellationToken cancellationToken);
        Task<int> DeleteCar(DeleteCarCommand carId, CancellationToken cancellationToken);
    }


}