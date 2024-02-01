using MediatR;

namespace OnlineShoping.Application.UseCases.Cards.Commands
{
    public class CreateCardsCommand : IRequest<bool>
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
