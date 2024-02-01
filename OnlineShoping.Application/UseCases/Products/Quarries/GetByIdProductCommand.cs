using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Products.Quarries
{
    public class GetByIdProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
