using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Users.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Users.Handlers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateUsersCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user is not null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                user.Password = request.Password;
                user.UpdatedAt = DateTime.UtcNow;
                _context.Users.Update(user);
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
