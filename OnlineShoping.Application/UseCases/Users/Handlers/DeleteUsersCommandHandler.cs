using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Users.Commands;

namespace OnlineShoping.Application.UseCases.Users.Handlers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public DeleteUsersCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (user is null)
                {
                    return false;
                }
                else
                {
                    _context.Users.Remove(user);
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
