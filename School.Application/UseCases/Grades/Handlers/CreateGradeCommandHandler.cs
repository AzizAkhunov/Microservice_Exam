using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Grades.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Grades.Handlers
{
    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateGradeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var grade = new Grade()
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                await _context.Grades.AddAsync(grade);
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
