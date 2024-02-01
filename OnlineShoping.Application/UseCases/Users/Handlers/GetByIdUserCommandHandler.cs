using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Users.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Users.Handlers
{
    public class GetByIdUserCommandHandler : IRequestHandler<GetByIdUserCommand, User>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdUserCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user is not null)
            {
                return user;
            }
            return new User();
        }
    }
}
