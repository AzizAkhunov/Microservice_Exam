using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.UseCases.Products.Commands
{
    public class DeleteProductsCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
