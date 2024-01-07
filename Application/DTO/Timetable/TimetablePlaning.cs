using Application.DTO.Cars;
using Application.DTO.Instructors;
using Application.DTO.Students;

namespace Application.DTO.Timetable
{
    public class TimetablePlaning
    {
        public List<DateTime> Date { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
        public IEnumerable<InstructorWithCategoryDTO> Instructors { get; set; }        
        public IEnumerable<CarDTO> Cars{ get; set; } 
        
    }
}
