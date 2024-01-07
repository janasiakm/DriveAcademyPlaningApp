using Application.Command.Timetables;
using Application.DTO.Timetable;

namespace Application.Interfaces
{
    public interface ITimetableService
    {
        Task<IEnumerable<TimetableList>> GetTimetables();
        Task<TimetablePlaning> GetDataForPlaningTimetable();
        //Task<StudentFullDTO> GetStudentById(int studentId);
        Task<int> AddTimetable(CreateTimetableCommand body, CancellationToken cancellationToken);
        //Task<int> UpdateStudent(UpdateStudentCommand body, CancellationToken cancellationToken);
        Task<int> DeleteTimetable(DeleteTimetableCommand Id, CancellationToken cancellationToken);

       
    }
}
