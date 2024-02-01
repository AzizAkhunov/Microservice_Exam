using MediatR;

namespace OnlineShoping.Application.UseCases.Carts.Commands
{
    public class CreateCartsCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
