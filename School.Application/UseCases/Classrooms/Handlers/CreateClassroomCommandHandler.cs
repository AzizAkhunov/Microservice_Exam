using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Classrooms.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Classrooms.Handlers
{
    public class CreateClassroomCommandHandler : IRequestHandler<CreateClassroomCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateClassroomCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var classroom = new Classroom()
                {
                    GradeId = request.GradeId,
                    TeacherId = request.TeacherId,
                };
                await _context.Classrooms.AddAsync(classroom);
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
