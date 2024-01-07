using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Timetable :Audity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumbersOfHours { get; set; }
        public string Category { get; set; } = "";
        public int InstructorId { get; set; } = 0;
        public int StudentId { get; set; } = 0;
        public int CarId { get; set; } = 0;
        public string Status { get; set; } = "";

    }

}

