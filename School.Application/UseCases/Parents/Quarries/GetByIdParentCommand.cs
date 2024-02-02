using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Parents.Quarries
{
    public class GetByIdParentCommand : IRequest<School.Domain.Entities.Parent>
    {
        public int Id { get; set; }
    }
}
