using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Addresses.Quarries;
using OnlineShoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.UseCases.Addresses.Handlers
{
    internal class GetAllAddressesCommandHandler : IRequestHandler<GetAllAddressesCommand, List<Address>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllAddressesCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> Handle(GetAllAddressesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Addresses.Include(x => x.Company).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
