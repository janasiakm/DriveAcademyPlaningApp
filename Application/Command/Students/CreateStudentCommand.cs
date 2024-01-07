using Application.DTO.Students;
using MediatR;

namespace Application.Command.Students
{
    public class CreateStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PESEL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Category { get; set; } = "";
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public string Status { get; set; }


        public CreateStudentCommand(StudentFullDTO student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            PESEL = student.PESEL.ToString();
            DateOfBirth = student.DateOfBirth;
            Category = student.Category;
            Adress = student.Adress;
            PostCode = student.PostCode;
            City = student.City;
            Email = student.Email;
            PhoneNr = student.PhoneNr;
            Status = student.Status;            
        }
    }
}
