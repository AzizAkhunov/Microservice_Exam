using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Categories.Quarries
{
    public class GetAllCategoriesCommand : IRequest<List<Category>>
    {
    }
}
