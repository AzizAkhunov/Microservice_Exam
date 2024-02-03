using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Courses.Commands;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Courses.Handlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateCourseCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (course is not null)
            {
                course.Name = request.Name;
                course.Description = request.Description;
                course.GradeId = request.GradeId;
                course.UpdatedAt = DateTime.UtcNow;

                _context.Courses.Update(course);
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
