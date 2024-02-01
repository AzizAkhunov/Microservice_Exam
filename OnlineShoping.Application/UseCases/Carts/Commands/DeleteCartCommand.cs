using MediatR;

namespace OnlineShoping.Application.UseCases.Carts.Commands
{
    public class DeleteCartCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
