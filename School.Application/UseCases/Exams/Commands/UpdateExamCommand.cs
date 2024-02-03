using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Exams.Commands
{
    public class UpdateExamCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int ExamTypeId { get; set; }
        public string Name { get; set; }
    }
}
