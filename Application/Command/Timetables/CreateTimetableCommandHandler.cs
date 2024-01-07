using Application.Interfaces;
using MediatR;

namespace Application.Command.Timetables
{
    public class CreateTimetableCommandHandler : IRequestHandler<CreateTimetableCommand, int>
    {
        private readonly ITimetableService _timetableService;

        public CreateTimetableCommandHandler(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        public async Task<int> Handle(CreateTimetableCommand request, CancellationToken cancellationToken)
        {
            return await _timetableService.AddTimetable(request, cancellationToken);
        }
    }
}