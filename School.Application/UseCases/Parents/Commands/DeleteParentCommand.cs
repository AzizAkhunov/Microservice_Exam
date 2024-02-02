using MediatR;

namespace School.Application.UseCases.Parent.Commands
{
    public class DeleteParentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
