using Application.DTO.Instructors;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Instructors
{
    public class GetInstructorByIdQueryHandler : IRequestHandler<GetInstructorByIdQuery, InstructorFullDTO>
    {
        private readonly IInstructorService _instructorService;

        public GetInstructorByIdQueryHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<InstructorFullDTO> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _instructorService.GetInstructorById(request.InstructorId);
        }
    }
}