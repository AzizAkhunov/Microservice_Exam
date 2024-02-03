using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Exams.Commands;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Exams.Handlers
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateExamCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            Exam? exam = await _context.Exams.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (exam is not null)
            {
                exam.ExamTypeId = request.ExamTypeId;
                exam.Name = request.Name;
                exam.UpdatedAt = DateTime.UtcNow;

                _context.Exams.Update(exam);
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
