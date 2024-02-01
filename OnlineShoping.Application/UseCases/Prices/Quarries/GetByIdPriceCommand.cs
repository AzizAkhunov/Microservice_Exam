using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Prices.Quarries
{
    public class GetByIdPriceCommand : IRequest<Price>
    {
        public int Id { get; set; }
    }
}
