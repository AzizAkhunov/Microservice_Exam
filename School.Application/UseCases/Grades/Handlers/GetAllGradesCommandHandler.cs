using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Grades.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Grades.Handlers
{
    public class GetAllGradesCommandHandler : IRequestHandler<GetAllGradesCommand, List<Grade>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllGradesCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Grade>> Handle(GetAllGradesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Grades.Include(x => x.Classrooms).Include(x => x.Courses).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
