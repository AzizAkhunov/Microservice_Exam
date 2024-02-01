using MediatR;

namespace OnlineShoping.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
