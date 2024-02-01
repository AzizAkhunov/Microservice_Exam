using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Orders.Quarries
{
    public class GetAllOrdersCommand : IRequest<List<Order>>
    {
    }
}
