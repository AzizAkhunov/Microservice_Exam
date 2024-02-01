using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Categories.Quarries
{
    public class GetByIdCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
