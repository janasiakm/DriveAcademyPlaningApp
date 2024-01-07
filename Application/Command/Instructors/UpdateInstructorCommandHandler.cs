using Application.Interfaces;
using MediatR;

namespace Application.Command.Instructors
{
    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, int>
    {
        private readonly IInstructorService _instructorService;

        public UpdateInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<int> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            return await _instructorService.UpdateInstructor(request, cancellationToken);
        }
    }
}