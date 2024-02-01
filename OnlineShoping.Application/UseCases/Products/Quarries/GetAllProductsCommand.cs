using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Products.Quarries
{
    public class GetAllProductsCommand : IRequest<List<Product>>
    {
    }
}
