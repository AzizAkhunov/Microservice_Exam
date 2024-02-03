using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamResults.Commands;

namespace School.Application.UseCases.ExamResults.Handlers
{
    public class DeleteExamResultCommandHandler : IRequestHandler<DeleteExamResultCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteExamResultCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteExamResultCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.ExamResults.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (exam is null)
                {
                    return false;
                }
                else
                {
                    _context.ExamResults.Remove(exam);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
