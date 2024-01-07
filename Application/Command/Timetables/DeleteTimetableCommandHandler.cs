using Application.Interfaces;
using MediatR;

namespace Application.Command.Timetables
{
    public class DeleteTimetableCommandHandler : IRequestHandler<DeleteTimetableCommand, int>
    {
        private readonly ITimetableService _timetableService;

        public DeleteTimetableCommandHandler(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        public async Task<int> Handle(DeleteTimetableCommand request, CancellationToken cancellationToken)
        {
            return await _timetableService.DeleteTimetable(request, cancellationToken);
        }
    }
}