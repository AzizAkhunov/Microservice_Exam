using MediatR;

namespace OnlineShoping.Application.UseCases.Prices.Commands
{
    public class UpdatePriceCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public decimal Pricee { get; set; }
        public int ProductId { get; set; }
    }
}
