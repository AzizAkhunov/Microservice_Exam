using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Quarries;
using School.Application.UseCases.Teachers.Commands;
using School.Application.UseCases.Teachers.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public TeachersController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTeacherAsync(TeacherDTO dto)
        {
            try
            {
                var command = new CreateTeacherCommand
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Name = dto.Name,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                };
                var value = _memoryCache.Get("Teacher_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Teacher_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllTeachersAsync()
        {
            try
            {
                var value = _memoryCache.Get("Teacher_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Teacher_key",
                        value: await _mediator.Send(new GetAllTeachersCommand()));
                }
                return Ok(_memoryCache.Get("Teacher_key") as List<Teacher>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTeacherAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteTeacherCommand { Id = id });
                var value = _memoryCache.Get("Teacher_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Teacher_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacherByIdAsync([FromForm] UpdateTeacherCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Teacher_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Teacher_key");
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
                var res = await _mediator.Send(new GetByIdTeacherCommand { Id = id });
                var value = _memoryCache.Get("Teacher_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Teacher_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
