using Application.DTO.Instructors;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Instructors
{
    public class GetCategoryInstructorQueryHandler : IRequestHandler<GetCategoryInstructorQuery, InstructorWithCategoryDTO>
    {
        private readonly IInstructorService _instructorService;

        public GetCategoryInstructorQueryHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<InstructorWithCategoryDTO> Handle(GetCategoryInstructorQuery request, CancellationToken cancellationToken)
        {
            var result = _instructorService.GetCategoryInstructorById(request.InstructorId);
            return result;
        }
    }

}