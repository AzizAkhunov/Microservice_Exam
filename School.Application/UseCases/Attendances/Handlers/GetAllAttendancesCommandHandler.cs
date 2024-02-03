using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Attendances.Quarries;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Attendances.Handlers
{
    public class GetAllAttendancesCommandHandler : IRequestHandler<GetAllAttendancesCommand, List<Attendance>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllAttendancesCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> Handle(GetAllAttendancesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Attendances.Include(x => x.Student).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
