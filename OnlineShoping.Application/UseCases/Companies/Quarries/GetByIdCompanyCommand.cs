using MediatR;
using OnlineShoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.UseCases.Companies.Quarries
{
    public class GetByIdCompanyCommand : IRequest<Company>
    {
        public int Id { get; set; }
    }
}
