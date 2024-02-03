using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Courses.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Courses.Handlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Course()
                {
                    Name = request.Name,
                    Description = request.Description,
                    GradeId = request.GradeId,
                };
                await _context.Courses.AddAsync(course);
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
