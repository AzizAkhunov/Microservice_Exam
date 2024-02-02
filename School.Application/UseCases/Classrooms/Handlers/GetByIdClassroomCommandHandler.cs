using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Classrooms.Quarries;
using School.Domain.Entities;

namespace School.Application.UseCases.Classrooms.Handlers
{
    public class GetByIdClassroomCommandHandler : IRequestHandler<GetByIdClassroomCommand, Classroom>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdClassroomCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Classroom> Handle(GetByIdClassroomCommand request, CancellationToken cancellationToken)
        {
            var cls = await _context.Classrooms.Include(x => x.Teacher).Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (cls is not null)
            {
                return cls;
            }
            return new Classroom();
        }
    }
}
