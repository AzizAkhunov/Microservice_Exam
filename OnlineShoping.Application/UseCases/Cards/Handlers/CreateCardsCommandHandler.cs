using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Cards.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Cards.Handlers
{
    public class CreateCardsCommandHandler : IRequestHandler<CreateCardsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreateCardsCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCardsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var card = new Card()
                {
                    CardNumber = request.CardNumber,
                    Amount = request.Amount,
                    UserId = request.UserId,
                };
                await _context.Cards.AddAsync(card);
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
