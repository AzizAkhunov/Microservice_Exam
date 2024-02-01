using MediatR;

namespace OnlineShoping.Application.UseCases.Prices.Commands
{
    public class DeletePriceCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
