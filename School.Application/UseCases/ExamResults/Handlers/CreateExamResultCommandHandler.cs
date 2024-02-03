using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.ExamResults.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.ExamResults.Handlers
{
    public class CreateExamResultCommandHandler : IRequestHandler<CreateExamResultCommand, bool>
    {
        private readonly ISchoolDbContext _context;
        public CreateExamResultCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateExamResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exam = new ExamResult()
                {
                    CourseId = request.CourseId,
                    ExamId = request.ExamId,
                    StudentId = request.StudentId,
                    Marks = request.Marks,
                };
                await _context.ExamResults.AddAsync(exam);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
