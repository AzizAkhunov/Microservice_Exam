using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Addresses.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Addresses.Handlers
{
    public class GetByIdAddressCommandHandler : IRequestHandler<GetByIdAddressCommand, Address>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdAddressCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Handle(GetByIdAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (address is not null)
            {
                return address;
            }
            return new Address();
        }
    }
}
