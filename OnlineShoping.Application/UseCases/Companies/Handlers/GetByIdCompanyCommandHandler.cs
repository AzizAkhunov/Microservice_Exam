using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Companies.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Companies.Handlers
{
    public class GetByIdCompanyCommandHandler : IRequestHandler<GetByIdCompanyCommand, Company>
    {
        private readonly IOnlineShopDbContext _context;
        public GetByIdCompanyCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<Company> Handle(GetByIdCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (company is not null)
            {
                return company;
            }
            return new Company();
        }
    }
}
