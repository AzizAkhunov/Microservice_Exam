using MediatR;

namespace OnlineShoping.Application.UseCases.Users.Commands
{
    public class DeleteUsersCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
