using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Products.Commands;

namespace OnlineShoping.Application.UseCases.Products.Handlers
{
    public class DeleteProducsCommandHandler : IRequestHandler<DeleteProductsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;
        public DeleteProducsCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (product is null)
                {
                    return false;
                }
                else
                {
                    _context.Products.Remove(product);
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
