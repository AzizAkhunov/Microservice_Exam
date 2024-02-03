using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Attendances.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Attendances.Handlers
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteAttendanceCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var att = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (att is null)
                {
                    return false;
                }
                else
                {
                    _context.Attendances.Remove(att);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
