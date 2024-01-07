using MediatR;

namespace Application.Command.Students
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }

        public DeleteStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
    }
}