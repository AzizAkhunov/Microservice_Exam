using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Grades.Quarries
{
    public class GetAllGradesCommand : IRequest<List<Grade>>
    {
    }
}
