using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Carts.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Carts.Handlers
{
    public class GetAllCartsCommandHandler : IRequestHandler<GetAllCartsCommand, List<Cart>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllCartsCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> Handle(GetAllCartsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Carts.Include(x => x.User).Include(x => x.Product).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
