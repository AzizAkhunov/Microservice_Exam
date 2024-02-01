using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Cards.Quarries
{
    public class GetAllCardsCommand : IRequest<List<Card>>
    {
    }
}
