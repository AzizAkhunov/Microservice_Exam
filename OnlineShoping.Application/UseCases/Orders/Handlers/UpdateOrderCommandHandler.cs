using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Orders.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Orders.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateOrderCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (order is not null)
            {
                order.UserId  = request.UserId;
                order.UpdatedAt = DateTime.UtcNow;

                _context.Orders.Update(order);
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
