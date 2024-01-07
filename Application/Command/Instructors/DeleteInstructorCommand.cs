using Application.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Command.Instructors
{
    public class DeleteInstructorCommand : IRequest<int>
    {
        public int InstructorId { get; set; }

        public DeleteInstructorCommand(int instructorId)
        {
            InstructorId = instructorId;
        }
    }
}