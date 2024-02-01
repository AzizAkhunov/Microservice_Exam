using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Carts.Quarries
{
    public class GetAllCartsCommand : IRequest<List<Cart>>
    {
    }
}
