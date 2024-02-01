using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Prices.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Prices.Handlers
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreatePriceCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var price = new Price()
                {
                    Pricee = request.Pricee,
                    ProductId = request.ProductId,
                };
                await _context.Prices.AddAsync(price);
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
