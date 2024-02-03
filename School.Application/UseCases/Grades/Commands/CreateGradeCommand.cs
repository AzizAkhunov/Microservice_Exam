using MediatR;

namespace School.Application.UseCases.Grades.Commands
{
    public class CreateGradeCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
