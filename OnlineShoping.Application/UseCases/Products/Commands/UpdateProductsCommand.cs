using MediatR;

namespace OnlineShoping.Application.UseCases.Products.Commands
{
    public class UpdateProductsCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; }
        public string ImgPath { get; set; }
    }
}
