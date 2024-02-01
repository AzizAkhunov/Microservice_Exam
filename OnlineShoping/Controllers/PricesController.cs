using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Commands;
using OnlineShoping.Application.UseCases.Categories.Quarries;
using OnlineShoping.Application.UseCases.Prices.Commands;
using OnlineShoping.Application.UseCases.Prices.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public PricesController(IMediator mediator, IMemoryCache memoryCache, IOnlineShopDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreatePriceAsync(PriceDTO dto)
        {
            try
            {
                var command = new CreatePriceCommand
                {
                    Pricee = dto.Pricee,
                    ProductId = dto.ProductId,
                };
                var value = _memoryCache.Get("Price_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Price_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllPricesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Price_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Price_key",
                        value: await _mediator.Send(new GetAllPricesCommand()));
                }
                return Ok(_memoryCache.Get("Price_key") as List<Price>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeletePriceAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeletePriceCommand { Id = id });
                var value = _memoryCache.Get("Price_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Price_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdatePriceByIdAsync([FromForm] UpdatePriceCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Price_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Price_key");
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
                var res = await _mediator.Send(new GetByIdPriceCommand { Id = id });
                var value = _memoryCache.Get("Price_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Price_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
