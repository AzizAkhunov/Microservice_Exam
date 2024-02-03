using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamResults.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamResults.Handlers
{
    public class GetByIdExamResultCommandHandler : IRequestHandler<GetByIdExamResultCommand, ExamResult>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdExamResultCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<ExamResult> Handle(GetByIdExamResultCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.ExamResults.Include(x => x.Course).Include(x => x.Exam).Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (exam is not null)
            {
                return exam;
            }
            return new ExamResult();
        }
    }
}
