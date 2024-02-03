using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Courses.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.Courses.Handlers
{
    public class GetByIdCourseCommandHandler : IRequestHandler<GetByIdCourseCommand, Course>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Course> Handle(GetByIdCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.Include(x => x.Grade).Include(x => x.ExamResults).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (course is not null)
            {
                return course;
            }
            return new Course();
        }
    }
}
