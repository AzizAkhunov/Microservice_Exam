using MediatR;

namespace OnlineShoping.Application.UseCases.Cards.Commands
{
    public class UpdateCardsCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
