using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Attendances.Quarries
{
    public class GetAllAttendancesCommand : IRequest<List<Attendance>>
    {
    }
}
