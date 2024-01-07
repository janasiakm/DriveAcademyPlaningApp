using Application.DTO.Instructors;
using Domain.Entities;
using MediatR;

namespace Application.Command.Instructors
{
    public class CreateInstructorCommand : IRequest<int>
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTimeOffset DateOfBirth { get; set; }
        public string IdNumber { get; set; } = "";
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public string Status { get; set; }


        public CreateInstructorCommand(InstructorFullDTO instructor)
        {
            FirstName = instructor.FirstName;
            LastName = instructor.LastName;
            DateOfBirth = instructor.DateOfBirth;
            IdNumber = instructor.IdNumber;
            Adress = instructor.Adress;
            PostCode = instructor.PostCode;
            City = instructor.City;
            Email = instructor.Email;
            PhoneNr = instructor.PhoneNr;
            Status = instructor.Status;
            
        }
    }
}
