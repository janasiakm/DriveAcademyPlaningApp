using Application.DTO.Instructors;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Instructors
{ 
    public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<InstructorWithCategoryDTO>>
    {
        private readonly IInstructorService _instructorService;

        public GetAllInstructorsQueryHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<IEnumerable<InstructorWithCategoryDTO>> Handle(GetAllInstructorsQuery request,CancellationToken cancellationToken)
        { 
            var result = await _instructorService.GetAllInstructors();
            return result; 
        }
    }
    
}   