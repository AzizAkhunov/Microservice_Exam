using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Classrooms.Commands;

namespace School.Application.UseCases.Classrooms.Handlers
{
    public class DeleteClassroomCommandHandler : IRequestHandler<DeleteClassroomCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteClassroomCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            var cls = await _context.Classrooms.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (cls is null)
                {
                    return false;
                }
                else
                {
                    _context.Classrooms.Remove(cls);
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
