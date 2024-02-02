using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Quarries
{
    public class GetByIdStudentCommand : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
