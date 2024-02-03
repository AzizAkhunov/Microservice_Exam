using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamResults.Quarries
{
    public class GetAllExamResultsCommand : IRequest<List<ExamResult>>
    { 
    }
}
