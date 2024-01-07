using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Instructors
{
    public class InstructorDTO
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";        
        public DateTime DateOfBirth { get; set; }         
        public string IdNumber { get; set; } = "";         
        


    }
}
