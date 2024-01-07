using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInstructorRepository
    {
        Instructor GetInstructorById(int id);
        Task<IEnumerable<Instructor>> GetAllAsync();
        
        Task<Instructor> GetByIdAsync(int instructorId);
        Task<int> AddAsync(Instructor instructor, CancellationToken cancellationToken);
        Task<int> UpdateAsync(Instructor instructor, CancellationToken cancellationToken);
        Task<int> DeleteAsync(int userId, CancellationToken cancellationToken);

        //Category
        Task<int> AddCategoryInstructor(int instructorId,CancellationToken cancellationToken);
        InstructorWithCategory GetCategoryInstructorAsync(int instructorId);
        Task<IEnumerable<InstructorWithCategory>> GetAllCategoryInstructorAsync();
        Task<int> UpdateCategoryAsync(InstructorWithCategory instructor, CancellationToken cancellationToken);

    }
}
