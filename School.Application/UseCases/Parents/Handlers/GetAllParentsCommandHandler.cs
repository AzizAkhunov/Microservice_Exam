using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Parent.Quarries;

namespace School.Application.UseCases.Parents.Handlers
{
    public class GetAllParentsCommandHandler : IRequestHandler<GetAllParentCommand, List<Domain.Entities.Parent>>
    {
        private readonly ISchoolDbContext _context;
        public GetAllParentsCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.Entities.Parent>> Handle(GetAllParentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Parents.Include(x => x.Childs).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
