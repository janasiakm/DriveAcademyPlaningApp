using Application.DTO.Students;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Students
{
    public class GetStudentByIdQuery : IRequest<StudentFullDTO>
    {
        public int StudentId { get; set; }

        public GetStudentByIdQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}


