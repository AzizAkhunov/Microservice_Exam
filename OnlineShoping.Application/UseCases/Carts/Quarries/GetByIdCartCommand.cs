using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Carts.Quarries
{
    public class GetByIdCartCommand : IRequest<Cart>
    {
        public int Id { get; set; }
    }
}
