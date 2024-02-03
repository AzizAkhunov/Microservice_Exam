using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamTypes.Commands;

namespace School.Application.UseCases.ExamTypes.Handlers
{
    public class DeleteExamTypeCommandHandler : IRequestHandler<DeleteExamTypeCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteExamTypeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteExamTypeCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.ExamTypes.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (exam is null)
                {
                    return false;
                }
                else
                {
                    _context.ExamTypes.Remove(exam);
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
