using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Quarries
{
    public class GetAllStudentsCommand : IRequest<List<Student>>
    {
    }
}
