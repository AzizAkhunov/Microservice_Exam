using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamResults.Quarries
{
    public class GetByIdExamResultCommand : IRequest<ExamResult>
    {
        public int Id { get; set; }
    }
}
