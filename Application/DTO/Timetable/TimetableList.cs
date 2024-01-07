using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Timetable
{
    public class TimetableList
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumbersOfHours { get; set; }
        public string Category { get; set; } = "";
        public string InstructorName { get; set; }
        public string StudentName { get; set; }
        public string CarName { get; set; }
        public string Status { get; set; }
    }
}
