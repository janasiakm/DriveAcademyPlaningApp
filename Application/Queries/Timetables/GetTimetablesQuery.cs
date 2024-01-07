using Application.DTO.Timetable;
using MediatR;

namespace Application.Queries.Timetables
{
    public class GetTimetablesQuery : IRequest<IEnumerable<TimetableList>> { }

        
}


