using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Attendances.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.Attendances.Handlers
{
    public class GetByIdAttendanceCommandHandler : IRequestHandler<GetByIdAttendanceCommand, Attendance>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdAttendanceCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> Handle(GetByIdAttendanceCommand request, CancellationToken cancellationToken)
        {
            var att = await _context.Attendances.Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (att is not null)
            {
                return att;
            }
            return new Attendance();
        }
    }
}
