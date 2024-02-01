using MediatR;

namespace OnlineShoping.Application.UseCases.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<bool>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int CompanyId { get; set; }
    }
}
