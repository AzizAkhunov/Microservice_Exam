using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.UseCases.Addresses.Commands;
using OnlineShoping.Application.UseCases.Addresses.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public AddressesController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAddressAsync(AddressDTO dto)
        {
            try
            {
                var command = new CreateAddressCommand
                {
                    Country = dto.Country,
                    City = dto.City,
                    CompanyId = dto.CompanyId,
                };
                var value = _memoryCache.Get("Address_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Address_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAddressAsync()
        {
            try
            {
                var value = _memoryCache.Get("Address_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Address_key",
                        value: await _mediator.Send(new GetAllAddressesCommand()));
                }
                return Ok(_memoryCache.Get("Address_key") as List<Address>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAddressAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteAddressCommand { Id = id });
                var value = _memoryCache.Get("Address_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Address_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAddressByIdAsync([FromForm] UpdateAddressCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Address_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Address_key");
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
                var res = await _mediator.Send(new GetByIdAddressCommand { Id = id });
                var value = _memoryCache.Get("Address_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Address_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
