using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Prices.Commands;

namespace OnlineShoping.Application.UseCases.Prices.Handlers
{
    public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public DeletePriceCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            var price = await _context.Prices.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (price is null)
                {
                    return false;
                }
                else
                {
                    _context.Prices.Remove(price);
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
