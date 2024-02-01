using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Users.Commands;
using OnlineShoping.Application.UseCases.Users.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public UsersController(IMediator mediator, IMemoryCache memoryCache, IOnlineShopDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UserDTO dto)
        {
            try
            {
                var command = new CreateUsersCommand
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                    Password = dto.Password,
                };
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsersAsync()
        {
            //var res = await _mediator.Send(new GetAllUsersCommand());
            //return Ok(res);
            try
            {
                var value = _memoryCache.Get("Users_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Users_key",
                        value: await _mediator.Send(new GetAllUsersCommand()));
                }
                return Ok(_memoryCache.Get("Users_key") as List<User>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteUsersCommand { Id = id });
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserByIdAsync([FromForm] UpdateUsersCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
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
                var res = await _mediator.Send(new GetByIdUserCommand { Id = id });
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
