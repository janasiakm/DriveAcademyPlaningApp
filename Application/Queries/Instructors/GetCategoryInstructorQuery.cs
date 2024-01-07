using Application.DTO;
using Application.DTO.Instructors;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Instructors
{
    public class GetCategoryInstructorQuery : IRequest<InstructorWithCategoryDTO>
    {
        public int InstructorId { get; set; }

        public GetCategoryInstructorQuery(int instructorId)
        {
            InstructorId = instructorId;
        }
    }


}


