using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamTypes.Quarries
{
    public class GetByIdExamTypeCommand : IRequest<ExamType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
