using MediatR;

namespace OnlineShoping.Application.UseCases.Products.Commands
{
    public class CreateProductsCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; }
        public string ImgPath { get; set; }
    }
}
