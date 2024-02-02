using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Classrooms.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Classrooms.Handlers
{
    public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateClassroomCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            Classroom? cls = await _context.Classrooms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (cls is not null)
            {
                cls.GradeId = request.GradeId;
                cls.TeacherId = request.TeacherId;
                cls.UpdatedAt = DateTime.UtcNow;

                _context.Classrooms.Update(cls);
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
