using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Products.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateProductCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product is not null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.CompanyId = request.CompanyId;
                product.CategoryId = request.CategoryId;
                product.Count = request.Count;
                product.ImgPath = request.ImgPath;

                _context.Products.Update(product);
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
