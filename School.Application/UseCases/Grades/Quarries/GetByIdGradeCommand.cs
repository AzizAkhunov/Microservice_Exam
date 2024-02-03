using MediatR;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Grades.Quarries
{
    public class GetByIdGradeCommand : IRequest<Grade>
    {
        public int Id { get; set; }
    }
}
