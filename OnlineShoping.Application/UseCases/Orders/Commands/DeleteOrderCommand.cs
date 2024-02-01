using MediatR;

namespace OnlineShoping.Application.UseCases.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
