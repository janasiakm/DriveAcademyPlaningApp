using Application.Command.Instructors;
using Application.DTO;
using Application.DTO.Instructors;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorWithCategoryDTO>> GetAllInstructors();
        Task<InstructorFullDTO> GetInstructorById(int instructorId);
        Task<int> AddInstructor(CreateInstructorCommand body, CancellationToken cancellationToken);
        Task<int> UpdateInstructor(UpdateInstructorCommand instructor, CancellationToken cancellationToken);
        Task<int> DeleteInstructor(DeleteInstructorCommand instructorId, CancellationToken cancellationToken);

        //Category
        InstructorWithCategoryDTO GetCategoryInstructorById(int instructorId);
        Task<int> UpdateCategoryInstructor(UpdateCategoryInstructorCommand instructor, CancellationToken cancellationToken);
    }
}
