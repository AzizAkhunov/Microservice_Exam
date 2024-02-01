using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Carts.Commands;

namespace OnlineShoping.Application.UseCases.Carts.Handlers
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public DeleteCartCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (cart is null)
                {
                    return false;
                }
                else
                {
                    _context.Carts.Remove(cart);
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
