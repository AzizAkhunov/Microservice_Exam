using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Exams.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.Exams.Handlers
{
    public class GetAllExamsCommandHandler : IRequestHandler<GetAllExamsCommand, List<Exam>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllExamsCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> Handle(GetAllExamsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Exams.Include(x => x.ExamType).Include(x => x.ExamResult).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
