using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Quarries
{
    public class GetAllTeachersCommand : IRequest<List<Teacher>>
    {
    }
}
