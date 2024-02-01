using MediatR;

namespace OnlineShoping.Application.UseCases.Addresses.Commands
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
