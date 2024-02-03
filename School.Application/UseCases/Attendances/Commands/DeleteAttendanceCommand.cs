using MediatR;

namespace School.Application.UseCases.Attendances.Commands
{
    public class DeleteAttendanceCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
