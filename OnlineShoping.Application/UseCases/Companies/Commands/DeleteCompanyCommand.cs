using MediatR;

namespace OnlineShoping.Application.UseCases.Companies.Commands
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
