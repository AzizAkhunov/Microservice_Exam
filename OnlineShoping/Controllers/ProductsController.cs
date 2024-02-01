using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Products.Commands;
using OnlineShoping.Application.UseCases.Products.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ProductsController(IMediator mediator, IMemoryCache memoryCache, IOnlineShopDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateProductAsync(ProductDTO dto)
        {
            try
            {
                var command = new CreateProductsCommand
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    CompanyId = dto.CompanyId,
                    CategoryId = dto.CategoryId,
                    Count = dto.Count,
                    ImgPath = dto.ImgPath,
                };
                var value = _memoryCache.Get("Products_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Products_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllProdutsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Products_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Products_key",
                        value: await _mediator.Send(new GetAllProductsCommand()));
                }
                return Ok(_memoryCache.Get("Products_key") as List<Product>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteProductsCommand { Id = id });
                var value = _memoryCache.Get("Products_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Products_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateProductByIdAsync([FromForm] UpdateProductsCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Products_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Products_key");
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
                var res = await _mediator.Send(new GetByIdProductCommand { Id = id });
                var value = _memoryCache.Get("Products_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Products_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
