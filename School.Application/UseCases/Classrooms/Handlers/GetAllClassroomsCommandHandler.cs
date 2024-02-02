using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Classrooms.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Classrooms.Handlers
{
    public class GetAllClassroomsCommandHandler : IRequestHandler<GetAllClassroomsCommand, List<Classroom>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllClassroomsCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Classroom>> Handle(GetAllClassroomsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Classrooms.Include(x => x.Teacher).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
