using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Cards.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Cards.Handlers
{
    public class GetByIdCardCommandHandler : IRequestHandler<GetByIdCardCommand, Card>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdCardCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Card> Handle(GetByIdCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (card is not null)
            {
                return card;
            }
            return new Card();
        }
    }
}
