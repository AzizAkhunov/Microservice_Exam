using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Attendances.Commands;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Attendances.Handlers
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateAttendanceCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var att = new Attendance()
                {
                    Date = request.Date,
                    StudentId = request.StudentId,
                    Status = request.Status,
                    Description = request.Description,
                };
                await _context.Attendances.AddAsync(att);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
