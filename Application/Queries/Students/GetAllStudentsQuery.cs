using Application.DTO.Students;
using MediatR;

namespace Application.Queries.Students
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDTO>> { }

        
}


