using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Parent.Commands;

namespace School.Application.UseCases.Parents.Handlers
{
    public class DeleteParentCommandHandler : IRequestHandler<DeleteParentCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteParentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
        {
            var parent = await _context.Parents.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (parent is null)
                {
                    return false;
                }
                else
                {
                    _context.Parents.Remove(parent);
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
