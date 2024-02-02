using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Students.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Students.Handlers
{
    public class GetAllStudentsCommandHandler : IRequestHandler<GetAllStudentsCommand, List<Student>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllStudentsCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Handle(GetAllStudentsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Students.Include(x => x.Parent).Include(x => x.Attendances).Include(x => x.Classrooms).Include(x=>x.ExamResults).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
