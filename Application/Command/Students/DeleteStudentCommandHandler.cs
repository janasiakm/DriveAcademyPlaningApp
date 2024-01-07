using Application.Interfaces;
using MediatR;

namespace Application.Command.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.DeleteStudent(request, cancellationToken);
        }
    }
}