using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Cards.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Cards.Handlers
{
    public class GetAllCardsCommandHandler : IRequestHandler<GetAllCardsCommand, List<Card>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllCardsCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Card>> Handle(GetAllCardsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Cards.Include(x => x.User).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
