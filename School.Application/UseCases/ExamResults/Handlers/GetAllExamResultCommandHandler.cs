using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamResults.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.ExamResults.Handlers
{
    public class GetAllExamResultCommandHandler : IRequestHandler<GetAllExamResultsCommand, List<ExamResult>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllExamResultCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamResult>> Handle(GetAllExamResultsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.ExamResults.Include(x => x.Course).Include(x => x.Exam).Include(x => x.Student).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
