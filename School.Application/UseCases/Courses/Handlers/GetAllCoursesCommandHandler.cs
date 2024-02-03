using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Courses.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Courses.Handlers
{
    public class GetAllCoursesCommandHandler : IRequestHandler<GetAllCoursesCommand, List<Course>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllCoursesCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> Handle(GetAllCoursesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Courses.Include(x => x.Grade).Include(x => x.ExamResults).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
