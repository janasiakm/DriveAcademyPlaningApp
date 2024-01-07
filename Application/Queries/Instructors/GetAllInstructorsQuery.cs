using Application.DTO;
using Application.DTO.Instructors;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Instructors
{
    public class GetAllInstructorsQuery : IRequest<IEnumerable<InstructorWithCategoryDTO>> { }

        
}


