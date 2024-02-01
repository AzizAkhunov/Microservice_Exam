using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Commands;
using OnlineShoping.Application.UseCases.Categories.Quarries;
using OnlineShoping.Application.UseCases.Orders.Commands;
using OnlineShoping.Application.UseCases.Orders.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public OrdersController(IMediator mediator, IMemoryCache memoryCache, IOnlineShopDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateOrderAsync(OrderDTO dto)
        {
            try
            {
                var command = new CreateOrderCommand
                {
                    UserId = dto.UserId,
                };
                var value = _memoryCache.Get("Order_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Order_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllOrdersAsync()
        {
            try
            {
                var value = _memoryCache.Get("Order_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Order_key",
                        value: await _mediator.Send(new GetAllOrdersCommand()));
                }
                return Ok(_memoryCache.Get("Order_key") as List<Order>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteOrderAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteOrderCommand { Id = id });
                var value = _memoryCache.Get("Order_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Order_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrderByIdAsync([FromForm] UpdateOrderCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Order_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Order_key");
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
                var res = await _mediator.Send(new GetByIdOrderCommand { Id = id });
                var value = _memoryCache.Get("Order_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Order_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
