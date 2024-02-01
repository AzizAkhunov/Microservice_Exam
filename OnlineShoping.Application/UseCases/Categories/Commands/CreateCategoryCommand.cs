using MediatR;

namespace OnlineShoping.Application.UseCases.Categories.Commands
{ 
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
