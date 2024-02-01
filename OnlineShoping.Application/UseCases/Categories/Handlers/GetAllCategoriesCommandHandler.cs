using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Categories.Handlers
{
    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllCategoriesCommand, List<Category>>
    {
        private readonly IOnlineShopDbContext _context;

        public GetAllCategoriesCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Categories.Include(x => x.Products).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
