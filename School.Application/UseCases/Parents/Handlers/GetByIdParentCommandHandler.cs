using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Parents.Quarries;

namespace School.Application.UseCases.Parents.Handlers
{
    public class GetByIdParentCommandHandler : IRequestHandler<GetByIdParentCommand, Domain.Entities.Parent>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdParentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Parent> Handle(GetByIdParentCommand request, CancellationToken cancellationToken)
        {
            var parent = await _context.Parents.Include(x => x.Childs).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (parent is not null)
            {
                return parent;
            }
            return new Domain.Entities.Parent();
        }
    }
}
