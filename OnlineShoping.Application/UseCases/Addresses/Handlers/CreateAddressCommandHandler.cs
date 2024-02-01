using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Addresses.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Addresses.Handlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreateAddressCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = new Address()
                {
                    Country = request.Country,
                    City = request.City,
                    CompanyId = request.CompanyId,
                };
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
