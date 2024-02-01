using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Products.Quarries;
using OnlineShoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.UseCases.Products.Handlers
{
    public class GetByIdProductCommandHandler : IRequestHandler<GetByIdProductCommand, Product>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdProductCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetByIdProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (product is not null)
            {
                return product;
            }
            return new Product();
        }
    }
}
