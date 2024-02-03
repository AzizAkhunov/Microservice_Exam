using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Exams.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Exams.Handlers
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateExamCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exam = new Exam()
                {
                    ExamTypeId = request.ExamTypeId,
                    Name = request.Name,
                };
                await _context.Exams.AddAsync(exam);
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
