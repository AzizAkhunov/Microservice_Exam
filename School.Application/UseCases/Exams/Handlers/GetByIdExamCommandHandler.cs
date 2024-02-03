using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Exams.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Exams.Handlers
{
    public class GetByIdExamCommandHandler : IRequestHandler<GetByIdExamCommand, Exam>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdExamCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Exam> Handle(GetByIdExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams.Include(x => x.ExamType).Include(x => x.ExamResult).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (exam is not null)
            {
                return exam;
            }
            return new Exam();
        }
    }
}
