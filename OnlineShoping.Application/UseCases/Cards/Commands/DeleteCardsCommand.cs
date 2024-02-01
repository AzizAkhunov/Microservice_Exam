using MediatR;

namespace OnlineShoping.Application.UseCases.Cards.Commands
{
    public class DeleteCardsCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
