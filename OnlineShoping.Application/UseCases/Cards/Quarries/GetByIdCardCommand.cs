using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Cards.Quarries
{
    public class GetByIdCardCommand : IRequest<Card>
    {
        public int Id { get; set; }
    }
}
