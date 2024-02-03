using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.ExamTypes.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.ExamTypes.Handlers
{
    public class GetAllExamTypesCommandHandler : IRequestHandler<GetAllExamTypesCommand, List<ExamType>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllExamTypesCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamType>> Handle(GetAllExamTypesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.ExamTypes.Include(x => x.Exam).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
