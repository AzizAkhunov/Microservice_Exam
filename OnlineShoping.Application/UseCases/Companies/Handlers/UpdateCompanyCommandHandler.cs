using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Companies.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Companies.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateCompanyCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (company is not null)
            {
                company.Name = request.Name;
                company.Description = request.Description;
                company.PhoneNumber = request.PhoneNumber;

                _context.Companies.Update(company);
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
