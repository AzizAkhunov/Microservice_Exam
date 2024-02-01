using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Cards.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Cards.Handlers
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateCardCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCardsCommand request, CancellationToken cancellationToken)
        {
            Card? card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (card is not null)
            {
                card.CardNumber = request.CardNumber;
                card.Amount = request.Amount;
                card.UserId = request.UserId;
                _context.Cards.Update(card);
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
