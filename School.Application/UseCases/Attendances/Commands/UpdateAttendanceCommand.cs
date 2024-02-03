using MediatR;

namespace School.Application.UseCases.Attendances.Commands
{
    public class UpdateAttendanceCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int StudentId { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
