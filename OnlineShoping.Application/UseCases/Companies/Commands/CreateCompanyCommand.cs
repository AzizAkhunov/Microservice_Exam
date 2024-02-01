using MediatR;

namespace OnlineShoping.Application.UseCases.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
