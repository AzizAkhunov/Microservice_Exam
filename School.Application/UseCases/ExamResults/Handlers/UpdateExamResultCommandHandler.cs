using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamResults.Commands;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.ExamResults.Handlers
{
    public class UpdateExamResultCommandHandler : IRequestHandler<UpdateExamResultCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateExamResultCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateExamResultCommand request, CancellationToken cancellationToken)
        {
            ExamResult? exam = await _context.ExamResults.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (exam is not null)
            {
                exam.ExamId = request.ExamId;
                exam.CourseId = request.CourseId;
                exam.StudentId = request.StudentId;
                exam.Marks = request.Marks;
                exam.UpdatedAt = DateTime.UtcNow;

                _context.ExamResults.Update(exam);
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
