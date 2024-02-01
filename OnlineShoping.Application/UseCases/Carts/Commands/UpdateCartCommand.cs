using MediatR;

namespace OnlineShoping.Application.UseCases.Carts.Commands
{
    public class UpdateCartCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }
    }
}
