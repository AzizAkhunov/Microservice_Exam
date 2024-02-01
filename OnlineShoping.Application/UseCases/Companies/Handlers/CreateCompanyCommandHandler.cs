using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Companies.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Companies.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreateCompanyCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = new Company()
                {
                    Name = request.Name,
                    Description = request.Description,
                    PhoneNumber = request.PhoneNumber,
                };
                await _context.Companies.AddAsync(company);
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
