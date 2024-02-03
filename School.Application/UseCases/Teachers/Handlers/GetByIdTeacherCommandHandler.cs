using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Teachers.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class GetByIdTeacherCommandHandler : IRequestHandler<GetByIdTeacherCommand, Teacher>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdTeacherCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> Handle(GetByIdTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.Include(x => x.Classroom).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (teacher is not null)
            {
                return teacher;
            }
            return new Teacher();
        }
    }
}
