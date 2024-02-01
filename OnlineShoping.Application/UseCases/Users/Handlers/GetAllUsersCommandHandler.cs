using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Users.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Users.Handlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<User>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllUsersCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Users.Include(x => x.Cards).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
