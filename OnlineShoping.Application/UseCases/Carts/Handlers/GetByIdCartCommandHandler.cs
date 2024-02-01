using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Carts.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Carts.Handlers
{
    public class GetByIdCartCommandHandler : IRequestHandler<GetByIdCartCommand, Cart>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdCartCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> Handle(GetByIdCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.Include(x => x.User).Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (cart is not null)
            {
                return cart;
            }
            return new Cart();
        }
    }
}
