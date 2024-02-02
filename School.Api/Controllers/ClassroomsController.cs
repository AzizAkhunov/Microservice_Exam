using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Classrooms.Commands;
using School.Application.UseCases.Classrooms.Quarries;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ClassroomsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateClassroomAsync(ClassroomDTO dto)
        {
            try
            {
                var command = new CreateClassroomCommand
                {
                    GradeId = dto.GradeId,
                    TeacherId = dto.TeacherId,
                };
                var value = _memoryCache.Get("Classroom_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Classroom_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllClassroomsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Classroom_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Classroom_key",
                        value: await _mediator.Send(new GetAllClassroomsCommand()));
                }
                return Ok(_memoryCache.Get("Classroom_key") as List<Classroom>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteClassroomAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteClassroomCommand { Id = id });
                var value = _memoryCache.Get("Classroom_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Classroom_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentByIdAsync([FromForm] UpdateClassroomCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Classroom_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Classroom_key");
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
                var res = await _mediator.Send(new GetByIdClassroomCommand { Id = id });
                var value = _memoryCache.Get("Classroom_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Classroom_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
