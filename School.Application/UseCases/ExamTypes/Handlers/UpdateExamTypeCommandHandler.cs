using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamTypes.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamTypes.Handlers
{
    public class UpdateExamTypeCommandHandler : IRequestHandler<UpdateExamTypeCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateExamTypeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateExamTypeCommand request, CancellationToken cancellationToken)
        {
            ExamType? exam = await _context.ExamTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (exam is not null)
            {
                exam.Name = request.Name;
                exam.Description = request.Description;
                exam.UpdatedAt = DateTime.UtcNow;

                _context.ExamTypes.Update(exam);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
