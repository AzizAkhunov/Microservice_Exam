using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Courses.Quarries
{
    public class GetByIdCourseCommand : IRequest<Course>
    {
        public int Id { get; set; }
    }
}
