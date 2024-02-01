using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.UseCases.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IOnlineShopDbContext _context;

        public DeleteCategoryCommandHandler(IOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (category is null)
                {
                    return false;
                }
                else
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
