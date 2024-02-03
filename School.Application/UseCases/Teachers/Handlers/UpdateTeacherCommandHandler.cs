using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Application.UseCases.Teachers.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public UpdateTeacherCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (teacher is not null)
            {
                teacher.Email = request.Email;
                teacher.Password = request.Password;
                teacher.Name = request.Name;
                teacher.LastName = request.LastName;
                teacher.PhoneNumber = request.PhoneNumber;
                teacher.UpdatedAt = DateTime.UtcNow;

                _context.Teachers.Update(teacher);
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
