using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Classrooms.Commands;
using School.Application.UseCases.Classrooms.Quarries;
using School.Application.UseCases.Grades.Commands;
using School.Application.UseCases.Grades.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public GradesController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateGradeAsync(GradeDTO dto)
        {
            try
            {
                var command = new CreateGradeCommand
                {
                    Name = dto.Name,
                    Description = dto.Description,
                };
                var value = _memoryCache.Get("Grade_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Grade_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllGradesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Grade_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Grade_key",
                        value: await _mediator.Send(new GetAllGradesCommand()));
                }
                return Ok(_memoryCache.Get("Grade_key") as List<Grade>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteGradeAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteGradeCommand { Id = id });
                var value = _memoryCache.Get("Grade_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Grade_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateGradeByIdAsync([FromForm] UpdateGradeCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Grade_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Grade_key");
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
                var res = await _mediator.Send(new GetByIdGradeCommand { Id = id });
                var value = _memoryCache.Get("Grade_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Grade_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
