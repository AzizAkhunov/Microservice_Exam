using MediatR;

namespace OnlineShoping.Application.UseCases.Companies.Commands
{
    public class UpdateCompanyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
