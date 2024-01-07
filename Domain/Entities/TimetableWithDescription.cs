using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TimetableWithDescription 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumbersOfHours { get; set; }
        public string Category { get; set; } = "";
        public string Instructor { get; set; } = "";
        public string Student { get; set; } = "";
        public string Car { get; set; } = "";

    }

}

