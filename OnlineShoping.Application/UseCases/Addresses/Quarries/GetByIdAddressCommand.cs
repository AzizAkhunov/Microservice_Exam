using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Addresses.Quarries
{
    public class GetByIdAddressCommand : IRequest<Address>
    {
        public int Id { get; set; }
    }
}
