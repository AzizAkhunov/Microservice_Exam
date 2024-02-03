using MediatR;

namespace School.Application.UseCases.ExamTypes.Commands
{
    public class UpdateExamTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
