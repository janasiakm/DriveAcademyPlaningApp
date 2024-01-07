using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICarRepository
    {
        Car GetCarById(int id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int carId);
        Task<int> AddAsync(Car body, CancellationToken cancellationToken);
        Task<int> UpdateAsync(Car body, CancellationToken cancellationToken);
        Task<int> DeleteAsync(int carId, CancellationToken cancellationToken);       

    }
}
