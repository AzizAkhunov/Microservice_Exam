using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Users.Quarries
{
    public class GetByIdUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
