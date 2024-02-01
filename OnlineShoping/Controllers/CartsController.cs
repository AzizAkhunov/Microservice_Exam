using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.UseCases.Cards.Commands;
using OnlineShoping.Application.UseCases.Cards.Quarries;
using OnlineShoping.Application.UseCases.Carts.Commands;
using OnlineShoping.Application.UseCases.Carts.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public CartsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCartAsync(CartDTO dto)
        {
            try
            {
                var command = new CreateCartsCommand
                {
                    UserId = dto.UserId,
                    ProductId = dto.ProductId,
                };
                var value = _memoryCache.Get("Carts_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Carts_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCartsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Carts_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Carts_key",
                        value: await _mediator.Send(new GetAllCartsCommand()));
                }
                return Ok(_memoryCache.Get("Carts_key") as List<Cart>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCartAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteCartCommand { Id = id });
                var value = _memoryCache.Get("Carts_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Carts_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCartByIdAsync([FromForm] UpdateCartCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Carts_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Carts_key");
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
                var res = await _mediator.Send(new GetByIdCartCommand { Id = id });
                var value = _memoryCache.Get("Carts_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Carts_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
