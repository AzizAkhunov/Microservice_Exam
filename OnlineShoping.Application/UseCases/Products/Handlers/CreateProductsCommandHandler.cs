using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Products.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Products.Handlers
{
    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreateProductsCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Product()
                {
                     Name = request.Name,
                    Description = request.Description,
                    CompanyId = request.CompanyId,
                    CategoryId = request.CategoryId,
                    Count = request.Count,
                    ImgPath = request.ImgPath,
                };
                await _context.Products.AddAsync(product);
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
