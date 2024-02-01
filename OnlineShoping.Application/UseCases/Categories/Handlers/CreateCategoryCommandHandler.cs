using MediatR;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Commands;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public CreateCategoryCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = new Category()
                {
                    Name = request.Name
                };
                await _context.Categories.AddAsync(category);
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
