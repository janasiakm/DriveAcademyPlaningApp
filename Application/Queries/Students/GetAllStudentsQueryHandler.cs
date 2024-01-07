using Application.DTO.Students;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Students
{ 
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDTO>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IEnumerable<StudentDTO>> Handle(GetAllStudentsQuery request,CancellationToken cancellationToken)
        { 
            var result = await _studentService.GetAllStudents();
            return result; 
        }
    }
    
}   