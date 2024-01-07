using Application.Interfaces;
using MediatR;

namespace Application.Command.Instructors
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, int>
    {
        private readonly IInstructorService _instructorService;

        public CreateInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<int> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            return await _instructorService.AddInstructor(request, cancellationToken);
        }
    }
}