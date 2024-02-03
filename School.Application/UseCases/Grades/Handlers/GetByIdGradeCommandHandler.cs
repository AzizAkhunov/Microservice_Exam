using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Grades.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.Grades.Handlers
{
    public class GetByIdGradeCommandHandler : IRequestHandler<GetByIdGradeCommand, Grade>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdGradeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Grade> Handle(GetByIdGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await _context.Grades.Include(x => x.Classrooms).Include(x=>x.Courses).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (grade is not null)
            {
                return grade;
            }
            return new Grade();
        }
    }
}
