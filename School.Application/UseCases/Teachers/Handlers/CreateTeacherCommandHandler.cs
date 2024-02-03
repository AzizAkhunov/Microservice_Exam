using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Teachers.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateTeacherCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = new Teacher()
                {
                    Email = request.Email,
                    Password = request.Password,
                    Name = request.LastName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                };
                await _context.Teachers.AddAsync(teacher);
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
