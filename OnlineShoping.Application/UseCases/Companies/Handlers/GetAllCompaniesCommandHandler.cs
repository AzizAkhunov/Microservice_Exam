using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Companies.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Companies.Handlers
{
    public class GetAllCompaniesCommandHandler : IRequestHandler<GetAllCompaniesCommand, List<Company>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllCompaniesCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> Handle(GetAllCompaniesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Companies.Include(x => x.Products).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
