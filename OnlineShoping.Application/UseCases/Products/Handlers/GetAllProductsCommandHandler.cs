using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Products.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Products.Handlers
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, List<Product>>
    {
        private readonly IOnlineShopDbContext _context;
        public GetAllProductsCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Products.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
