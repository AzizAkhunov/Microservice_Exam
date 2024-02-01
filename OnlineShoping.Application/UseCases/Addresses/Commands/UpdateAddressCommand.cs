using MediatR;

namespace OnlineShoping.Application.UseCases.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int CompanyId { get; set; }
    }
}
