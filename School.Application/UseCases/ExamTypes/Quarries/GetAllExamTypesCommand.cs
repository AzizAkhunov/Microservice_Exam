using MediatR;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.ExamTypes.Quarries
{
    public class GetAllExamTypesCommand : IRequest<List<ExamType>>
    {
    }
}
