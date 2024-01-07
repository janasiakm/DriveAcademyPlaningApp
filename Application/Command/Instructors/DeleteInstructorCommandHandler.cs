using Application.Interfaces;
using MediatR;

namespace Application.Command.Instructors
{
    public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, int>
    {
        private readonly IInstructorService _instructorService;

        public DeleteInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<int> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            return await _instructorService.DeleteInstructor(request, cancellationToken);
        }
    }
}