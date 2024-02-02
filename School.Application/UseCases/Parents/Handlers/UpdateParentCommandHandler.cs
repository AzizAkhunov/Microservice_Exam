using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Parent.Commands;

namespace School.Application.UseCases.Parents.Handlers
{
    public class UpdateParentCommandHandler : IRequestHandler<UpdateParentCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateParentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateParentCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Parent? parent = await _context.Parents.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (parent is not null)
            {
                parent.Email = request.Email;
                parent.Password = request.Password;
                parent.Name = request.Name;
                parent.LastName = request.LastName;
                parent.PhoneNumber = request.PhoneNumber;
                parent.UpdatedAt = DateTime.UtcNow;

                _context.Parents.Update(parent);
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
