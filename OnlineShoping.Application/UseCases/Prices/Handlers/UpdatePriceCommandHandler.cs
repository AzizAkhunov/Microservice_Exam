using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Prices.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Prices.Handlers
{
    public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdatePriceCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            Price? price = await _context.Prices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (price is not null)
            {
                price.Pricee = request.Pricee;
                price.ProductId = request.ProductId;
                price.UpdatedAt = DateTime.UtcNow;

                _context.Prices.Update(price);
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
