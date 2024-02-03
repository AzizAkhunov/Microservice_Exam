using MediatR;

namespace School.Application.UseCases.ExamResults.Commands
{
    public class DeleteExamResultCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
