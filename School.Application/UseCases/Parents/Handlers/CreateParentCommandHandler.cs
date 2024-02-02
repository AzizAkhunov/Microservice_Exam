using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.Parent.Commands;

namespace School.Application.UseCases.Parents.Handlers
{
    public class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateParentCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateParentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var parent = new Domain.Entities.Parent()
                {
                    Email = request.Email,
                    Password = request.Password,
                    Name = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                };
                await _context.Parents.AddAsync(parent);
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
