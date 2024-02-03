using MediatR;

namespace School.Application.UseCases.Courses.Commands
{
    public class CreateCourseCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GradeId { get; set; }
    }
}
