using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamTypes.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamTypes.Handlers
{
    public class GetByIdExamTypeCommandHandler : IRequestHandler<GetByIdExamTypeCommand, ExamType>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdExamTypeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<ExamType> Handle(GetByIdExamTypeCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.ExamTypes.Include(x => x.Exam).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (exam is not null)
            {
                return exam;
            }
            return new ExamType();
        }
    }
}
