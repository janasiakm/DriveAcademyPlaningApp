using Application.DTO.Timetable;
using MediatR;

namespace Application.Command.Timetables
{
    public class CreateTimetableCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public int SelectedHour { get; set; }
        public int NumbersOfHours { get; set; }
        public string Category { get; set; } = "";
        public int InstructorId { get; set; } = 0;
        public int StudentId { get; set; } = 0;
        public int CarId { get; set; } = 0;
        public string Status { get; set; } = "";


        public CreateTimetableCommand(TimetableAdd body)
        {
            Date = body.Date;
            SelectedHour = body.SelectedHour;
            NumbersOfHours = body.NumbersOfHours;
            Category = body.Category;
            InstructorId = body.InstructorId;
            StudentId = body.StudentId;
            CarId = body.CarId;
            Status = body.Status;            
        }
    }
}
