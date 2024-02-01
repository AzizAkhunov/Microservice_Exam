using MediatR;

namespace OnlineShoping.Application.UseCases.Prices.Commands
{
    public class CreatePriceCommand : IRequest<bool>
    {
        public decimal Pricee { get; set; }
        public int ProductId { get; set; }
    }
}
