using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentById(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int studentId);
        Task<int> AddAsync(Student body, CancellationToken cancellationToken);
        Task<int> UpdateAsync(Student body, CancellationToken cancellationToken);
        Task<int> DeleteAsync(int studentId, CancellationToken cancellationToken);       

    }
}
