using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public UpdateCategoryCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (category is not null)
            {
                category.Name = request.Name;
                category.UpdatedAt = DateTime.UtcNow;

                _context.Categories.Update(category);
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
