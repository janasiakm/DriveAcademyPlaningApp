using Application.Interfaces;
using MediatR;

namespace Application.Command.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentService _studentService;

        public CreateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.AddStudent(request, cancellationToken);
        }
    }
}