using MediatR;

namespace Application.Command.Timetables
{
    public class DeleteTimetableCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteTimetableCommand(int id)
        {
            Id = id;          
        }
    }
}
