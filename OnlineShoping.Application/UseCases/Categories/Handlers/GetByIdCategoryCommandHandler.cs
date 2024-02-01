using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Quarries;
using OnlineShoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.UseCases.Categories.Handlers
{
    public class GetByIdCategoryCommandHandler : IRequestHandler<GetByIdCategoryCommand, Category>
    {
        private readonly IOnlineShopDbContext _context;

        public GetByIdCategoryCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetByIdCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category is not null)
            {
                return category;
            }
            return new Category();
        }
    }
}
