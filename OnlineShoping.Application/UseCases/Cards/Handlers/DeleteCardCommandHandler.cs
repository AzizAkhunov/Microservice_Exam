using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Cards.Commands;

namespace OnlineShoping.Application.UseCases.Cards.Handlers
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardsCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public DeleteCardCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCardsCommand request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (card is null)
                {
                    return false;
                }
                else
                {
                    _context.Cards.Remove(card);
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
