using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Users.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Users.Handlers
{
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreateUsersCommandHandler(IOnlineShopDbContext onlineShopDbContext)
        {
            _context = onlineShopDbContext;
        }

        public async Task<bool> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password,
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
