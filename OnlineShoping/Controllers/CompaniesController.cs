using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Companies.Commands;
using OnlineShoping.Application.UseCases.Companies.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public CompaniesController(IMediator mediator, IMemoryCache memoryCache, IOnlineShopDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCompanyAsync(CompanyDTO dto)
        {
            try
            {
                var command = new CreateCompanyCommand
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    PhoneNumber = dto.PhoneNumber,
                };
                var value = _memoryCache.Get("Company_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Company_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCompaniesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Company_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Company_key",
                        value: await _mediator.Send(new GetAllCompaniesCommand()));
                }
                return Ok(_memoryCache.Get("Company_key") as List<Company>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCompanyAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteCompanyCommand { Id = id });
                var value = _memoryCache.Get("Company_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Company_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCompanyByIdAsync([FromForm] UpdateCompanyCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Company_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Company_key");
                }
                return Ok(await _mediator.Send(dto));
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdCompanyCommand { Id = id });
                var value = _memoryCache.Get("Company_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Company_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
