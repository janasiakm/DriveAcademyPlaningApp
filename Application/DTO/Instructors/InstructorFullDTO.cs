using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Instructors
{
    public class InstructorFullDTO
    {
        public int InstructorId { get; set; }
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";        
        public DateTime DateOfBirth { get; set; }         
        public string? IdNumber { get; set; } = "";
        public string? Adress { get; set; } = "";
        public string? PostCode { get; set; } = "";
        public string? City { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? PhoneNr { get; set; } = "";
        public string? Status { get; set; } = "";
        public DateTime Modyfication { get; set; }
    }
}
