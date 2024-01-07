using Application.Interfaces;
using MediatR;

namespace Application.Command.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.UpdateStudent(request, cancellationToken);
        }
    }
}