using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Attendances.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Attendances.Handlers
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateAttendanceCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance? att = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (att is not null)
            {
                att.Date = request.Date;
                att.StudentId = request.StudentId;
                att.Status = request.Status;
                att.Description = request.Description;
                att.UpdatedAt = DateTime.UtcNow;

                _context.Attendances.Update(att);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
