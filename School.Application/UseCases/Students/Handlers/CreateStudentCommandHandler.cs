using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Students.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateStudentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = new Student()
                {
                    Email = request.Email,
                    Password = request.Password,
                    Name = request.LastName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    ParentId = request.ParentId,
                };
                await _context.Students.AddAsync(student);
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
