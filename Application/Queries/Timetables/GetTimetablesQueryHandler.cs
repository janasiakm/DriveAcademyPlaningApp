using Application.DTO.Timetable;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Timetables
{ 
    public class GetTimetablesQueryHandler : IRequestHandler<GetTimetablesQuery, IEnumerable<TimetableList>>
    {
        private readonly ITimetableService _timetableService;

        public GetTimetablesQueryHandler(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        public async Task<IEnumerable<TimetableList>> Handle(GetTimetablesQuery request,CancellationToken cancellationToken)
        { 
            var result = await _timetableService.GetTimetables();
            return result; 
        }
    }
    
}   