using Application.DTO.Timetable;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Timetables
{ 
    public class GetDataForPlaningTimetableQueryHandler : IRequestHandler<GetDataForPlaningTimetableQuery, TimetablePlaning>
    {
        private readonly ITimetableService _timetableService;

        public GetDataForPlaningTimetableQueryHandler(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        public async Task<TimetablePlaning> Handle(GetDataForPlaningTimetableQuery request,CancellationToken cancellationToken)
        { 
            var result = await _timetableService.GetDataForPlaningTimetable();
            return result; 
        }
    }
    
}   