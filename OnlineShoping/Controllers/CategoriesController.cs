using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Categories.Commands;
using OnlineShoping.Application.UseCases.Categories.Quarries;
using OnlineShoping.Application.UseCases.Companies.Commands;
using OnlineShoping.Application.UseCases.Companies.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public CategoriesController(IMediator mediator, IMemoryCache memoryCache, IOnlineShopDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCategoryAsync(CategoryDTO dto)
        {
            try
            {
                var command = new CreateCategoryCommand
                {
                    Name = dto.Name,
                };
                var value = _memoryCache.Get("Category_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Category_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCategoriesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Category_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Category_key",
                        value: await _mediator.Send(new GetAllCategoriesCommand()));
                }
                return Ok(_memoryCache.Get("Category_key") as List<Category>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteCategoryCommand { Id = id });
                var value = _memoryCache.Get("Category_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Category_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCategoryByIdAsync([FromForm] UpdateCategoryCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Category_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Category_key");
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
                var res = await _mediator.Send(new GetByIdCategoryCommand { Id = id });
                var value = _memoryCache.Get("Category_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Category_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
