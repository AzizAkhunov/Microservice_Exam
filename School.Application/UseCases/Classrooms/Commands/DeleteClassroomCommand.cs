using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Classrooms.Commands
{
    public class DeleteClassroomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
