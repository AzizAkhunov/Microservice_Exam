using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Quarries
{
    public class GetByIdTeacherCommand : IRequest<Teacher>
    {
        public int Id { get; set; }
    }
}
