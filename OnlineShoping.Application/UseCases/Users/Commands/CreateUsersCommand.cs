using MediatR;

namespace OnlineShoping.Application.UseCases.Users.Commands
{
    public class CreateUsersCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
