using MediatR;

namespace School.Application.UseCases.Parent.Quarries
{
    public class GetAllParentCommand : IRequest<List<Domain.Entities.Parent>>
    {
    }
}
