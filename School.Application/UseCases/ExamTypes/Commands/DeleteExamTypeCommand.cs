using MediatR;

namespace School.Application.UseCases.ExamTypes.Commands
{
    public class DeleteExamTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
