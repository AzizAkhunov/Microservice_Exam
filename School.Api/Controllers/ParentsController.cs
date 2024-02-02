using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Parent.Commands;
using School.Application.UseCases.Parent.Quarries;
using School.Application.UseCases.Parents.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ParentsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateParentAsync(ParentDTO dto)
        {
            try
            {
                var command = new CreateParentCommand
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Name = dto.Name,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                };
                var value = _memoryCache.Get("Parent_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Parent_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllParentsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Parent_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Parent_key",
                        value: await _mediator.Send(new GetAllParentCommand()));
                }
                return Ok(_memoryCache.Get("Parent_key") as List<Parent>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteParentAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteParentCommand { Id = id });
                var value = _memoryCache.Get("Parent_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Parent_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAddressByIdAsync([FromForm] UpdateParentCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Parent_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Parent_key");
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
                var res = await _mediator.Send(new GetByIdParentCommand { Id = id });
                var value = _memoryCache.Get("Parent_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Parent_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
