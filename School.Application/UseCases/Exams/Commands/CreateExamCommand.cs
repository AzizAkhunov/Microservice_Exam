using MediatR;

namespace School.Application.UseCases.Exams.Commands
{
    public class CreateExamCommand : IRequest<bool>
    {
        public int ExamTypeId { get; set; }
        public string Name { get; set; }
    }
}
