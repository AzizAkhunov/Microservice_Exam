using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.ExamTypes.Commands
{
    public class CreateExamTypeCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
