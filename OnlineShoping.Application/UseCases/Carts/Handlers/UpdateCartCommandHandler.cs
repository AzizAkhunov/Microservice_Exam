using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Carts.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Carts.Handlers
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;
        public UpdateCartCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (cart is not null)
            {
                cart.UserId = request.UserId;
                cart.ProductId = request.ProductId;
                cart.Active = request.Active;
                _context.Carts.Update(cart);
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
