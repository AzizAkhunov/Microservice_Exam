using MediatR;

namespace School.Application.UseCases.Parent.Commands
{
    public class CreateParentCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
