using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Prices.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Prices.Handlers
{
    public class GetByIdPriceCommandHandler : IRequestHandler<GetByIdPriceCommand, Price>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdPriceCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Price> Handle(GetByIdPriceCommand request, CancellationToken cancellationToken)
        {
            var price = await _context.Prices.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (price is not null)
            {
                return price;
            }
            return new Price();
        }
    }
}
