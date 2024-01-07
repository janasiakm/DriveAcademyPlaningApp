using Application.Interfaces;
using MediatR;

namespace Application.Command.Instructors
{ 
    public class UpdateCategoryInstructorCommandHandler : IRequestHandler<UpdateCategoryInstructorCommand, int>
    {
        private readonly IInstructorService _instructorService;

        public UpdateCategoryInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<int> Handle(UpdateCategoryInstructorCommand request, CancellationToken cancellationToken)
        {
            return await _instructorService.UpdateCategoryInstructor(request, cancellationToken);
        }
    }
}   