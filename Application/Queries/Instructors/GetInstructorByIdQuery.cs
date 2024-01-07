using Application.DTO.Instructors;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Instructors
{
    public class GetInstructorByIdQuery : IRequest<InstructorFullDTO>
    {
        public int InstructorId { get; set; }

        public GetInstructorByIdQuery(int instructorId)
        {
            InstructorId = instructorId;
        }
    }
}


