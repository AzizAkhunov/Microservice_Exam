using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Classrooms.Quarries
{
    public class GetAllClassroomsCommand : IRequest<List<Classroom>>
    {
    }
}
