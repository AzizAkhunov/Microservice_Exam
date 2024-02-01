using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Users.Quarries
{
    public class GetAllUsersCommand : IRequest<List<User>>
    {
    }
}
