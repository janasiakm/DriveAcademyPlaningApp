using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITimetableRepository
    {
        Task<IEnumerable<TimetableWithDescription>> GetAllAsync();        
        Task<int> AddAsync(Timetable body, CancellationToken cancellationToken);
        Task<int> DeleteAsync(int id, CancellationToken cancellationToken);       

    }
}
