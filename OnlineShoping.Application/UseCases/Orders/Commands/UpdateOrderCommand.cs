using MediatR;

namespace OnlineShoping.Application.UseCases.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
