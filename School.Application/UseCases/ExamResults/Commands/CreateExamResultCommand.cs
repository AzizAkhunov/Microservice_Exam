using MediatR;

namespace School.Application.UseCases.ExamResults.Commands
{
    public class CreateExamResultCommand : IRequest<bool>
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Marks { get; set; }
    }
}
