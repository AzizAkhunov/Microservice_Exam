using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Grades.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Grades.Handlers
{
    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateGradeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            Grade? grade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (grade is not null)
            {
                grade.Name = request.Name;
                grade.Description = request.Description;
                grade.UpdatedAt = DateTime.UtcNow;

                _context.Grades.Update(grade);
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
