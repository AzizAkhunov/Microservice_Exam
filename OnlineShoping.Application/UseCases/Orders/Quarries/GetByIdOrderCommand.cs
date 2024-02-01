using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Orders.Quarries
{
    public class GetByIdOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
