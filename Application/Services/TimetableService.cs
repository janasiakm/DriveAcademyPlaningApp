using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Application.DTO.Timetable;
using Application.Command.Timetables;


namespace Application.Services
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly IInstructorService _instruktorService;
        private readonly IStudentService _studentService;
        private readonly ICarService _carService;

        public TimetableService(ITimetableRepository timetablerepository, IInstructorService instruktorService, IStudentService studentService, ICarService carService)
        {
            _timetableRepository = timetablerepository;
            _instruktorService = instruktorService;
            _studentService = studentService;
            _carService = carService;
        }

        public async Task<TimetablePlaning> GetDataForPlaningTimetable()
        {
            var dates = new List<DateTime>();

            for (int i = 0; i < 14; i++) { 
                dates.Add(DateTime.Now.AddDays(i));            
            }
            var instructors = _instruktorService.GetAllInstructors().Result;
            var students = _studentService.GetAllStudents().Result;
            var cars = _carService.GetAllCars().Result;

            var result = new TimetablePlaning{
                Date = dates,
                Instructors = instructors,
                Students = students,
                Cars = cars                              
            };
            return result;
         }
        public async Task<IEnumerable<TimetableList>> GetTimetables()
        {
            var data = _timetableRepository.GetAllAsync();
            List<TimetableList> result = new List<TimetableList>();

            foreach (var item in data.Result)
            {
                result.Add(new TimetableList{
                    Id = item.Id,
                    Date = item.Date,
                    NumbersOfHours = item.NumbersOfHours,
                    Category = item.Category,
                    InstructorName = item.Instructor,
                    StudentName = item.Student,
                    CarName = item.Car                    
                });
            }
            return result;
        }

        public async Task<int> AddTimetable(CreateTimetableCommand body, CancellationToken cancellationToken)
        {
            var timetable = new Timetable{
                Date = body.Date.AddHours(body.SelectedHour),
                NumbersOfHours = body.NumbersOfHours,
                Category = body.Category,
                InstructorId = body.InstructorId,
                StudentId = body.StudentId,
                CarId = body.CarId,
                Status = body.Status,
                };                       
           return  await _timetableRepository.AddAsync(timetable, cancellationToken);   
        }

        public async Task<int> DeleteTimetable(DeleteTimetableCommand body, CancellationToken cancellationToken)
        {
           return await _timetableRepository.DeleteAsync(body.Id, cancellationToken);
        }
    }
}
