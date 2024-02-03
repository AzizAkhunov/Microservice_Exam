using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Attendances.Quarries
{
    public class GetByIdAttendanceCommand : IRequest<Attendance>
    {
        public int Id { get; set; }
    }
}
