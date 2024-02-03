using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Grades.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Grades.Handlers
{
    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteGradeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (grade is null)
                {
                    return false;
                }
                else
                {
                    _context.Grades.Remove(grade);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
