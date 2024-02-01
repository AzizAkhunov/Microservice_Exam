using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Addresses.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Addresses.Handlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateAddressCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (address is not null)
            {
                address.Country = request.Country;
                address.City = request.City;
                address.CompanyId = request.CompanyId;
                address.UpdatedAt = DateTime.UtcNow;

                _context.Addresses.Update(address);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
