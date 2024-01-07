using Application.DTO.Instructors;
using Domain.Entities;
using MediatR;

namespace Application.Command.Instructors
{
    public class UpdateInstructorCommand : IRequest<int>
    {
        public int InstructorId { get; set; }
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
        public DateTime Created { get; set; }
        public DateTime Modification { get; set; } = DateTime.Now;


        public UpdateInstructorCommand(InstructorFullDTO instructor)
        {
            InstructorId = instructor.InstructorId;
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