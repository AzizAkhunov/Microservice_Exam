using MediatR;

namespace School.Application.UseCases.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GradeId { get; set; }
    }
}
