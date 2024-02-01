using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Prices.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Prices.Handlers
{
    public class GetAllPricesCommandHandler : IRequestHandler<GetAllPricesCommand, List<Price>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllPricesCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Price>> Handle(GetAllPricesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Prices.Include(x => x.Product).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
