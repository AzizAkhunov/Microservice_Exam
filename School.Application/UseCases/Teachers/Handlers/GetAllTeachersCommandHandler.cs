using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Teachers.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class GetAllTeachersCommandHandler : IRequestHandler<GetAllTeachersCommand, List<Teacher>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllTeachersCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Handle(GetAllTeachersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Teachers.Include(x => x.Classroom).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
