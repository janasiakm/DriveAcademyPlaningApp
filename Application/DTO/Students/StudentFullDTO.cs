using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.DTO.Students
{
    public class StudentFullDTO
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";        
        public string? PESEL { get; set; }        
        public DateTime DateOfBirth { get; set; }         
        public string? Category { get; set; } = "";
        public string? Adress { get; set; } = "";
        public string? PostCode { get; set; } = "";
        public string? City { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? PhoneNr { get; set; } = "";
        public string? Status { get; set; } = "";
        public DateTime Modyfication { get; set; }
    }
}
