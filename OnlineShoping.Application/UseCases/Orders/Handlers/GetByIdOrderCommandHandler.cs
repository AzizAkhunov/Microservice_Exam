using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Orders.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Orders.Handlers
{
    public class GetByIdOrderCommandHandler : IRequestHandler<GetByIdOrderCommand, Order>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdOrderCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetByIdOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (order is not null)
            {
                return order;
            }
            return new Order();
        }
    }
}
