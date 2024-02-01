using MediatR;

namespace OnlineShoping.Application.UseCases.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
