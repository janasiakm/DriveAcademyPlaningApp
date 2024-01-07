using Application.Command.Instructors;
using Application.Command.Students;
using Application.DTO.Students;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudents();
        Task<StudentFullDTO> GetStudentById(int studentId);
        Task<int> AddStudent(CreateStudentCommand body, CancellationToken cancellationToken);
        Task<int> UpdateStudent(UpdateStudentCommand body, CancellationToken cancellationToken);
        Task<int> DeleteStudent(DeleteStudentCommand studentId, CancellationToken cancellationToken);

       
    }
}
