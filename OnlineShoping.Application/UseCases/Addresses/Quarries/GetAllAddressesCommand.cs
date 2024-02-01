using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Addresses.Quarries
{
    public class GetAllAddressesCommand : IRequest<List<Address>>
    {
    }
}
