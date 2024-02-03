using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Exams.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Exams.Handlers
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteExamCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (exam is null)
                {
                    return false;
                }
                else
                {
                    _context.Exams.Remove(exam);
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
