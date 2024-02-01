using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Carts.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Carts.Handlers
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;
        public CreateCartCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateCartsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = new Cart()
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                };
                await _context.Carts.AddAsync(cart);
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
