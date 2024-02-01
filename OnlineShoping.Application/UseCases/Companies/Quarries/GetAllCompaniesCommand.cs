using MediatR;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.Application.UseCases.Companies.Quarries
{
    public class GetAllCompaniesCommand : IRequest<List<Company>>
    {
    }
}
