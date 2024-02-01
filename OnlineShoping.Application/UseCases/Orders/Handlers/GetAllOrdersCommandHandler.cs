using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Orders.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Orders.Handlers
{
    public class GetAllOrdersCommandHandler : IRequestHandler<GetAllOrdersCommand, List<Order>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllOrdersCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Orders.Include(x => x.User).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
