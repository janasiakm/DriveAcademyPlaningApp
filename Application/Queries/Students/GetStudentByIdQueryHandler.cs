using Application.DTO.Students;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Students
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentFullDTO>
    {
        private readonly IStudentService _studentService;

        public GetStudentByIdQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentFullDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentById(request.StudentId);
        }
    }
}