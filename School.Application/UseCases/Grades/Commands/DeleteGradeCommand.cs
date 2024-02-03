using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Grades.Commands
{
    public class DeleteGradeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
