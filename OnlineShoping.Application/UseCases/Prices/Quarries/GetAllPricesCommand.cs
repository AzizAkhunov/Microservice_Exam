using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Prices.Quarries
{
    public class GetAllPricesCommand : IRequest<List<Price>>
    {
    }
}
