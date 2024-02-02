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
    public class GetByIdStudentCommandHandler : IRequestHandler<GetByIdStudentCommand, Student>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdStudentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetByIdStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.Include(x => x.Attendances).Include(x => x.Classrooms).Include(x => x.ExamResults).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (student is not null)
            {
                return student;
            }
            return new Student();
        }
    }
}
