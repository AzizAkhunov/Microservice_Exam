using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.ExamTypes.Commands;
using School.Application.UseCases.ExamTypes.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ExamTypesController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateExamTypeAsync(ExamTypeDTO dto)
        {
            try
            {
                var command = new CreateExamTypeCommand
                {
                    Name = dto.Name,
                    Description = dto.Description,
                };
                var value = _memoryCache.Get("ExamType_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamType_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllExamTypesAsync()
        {
            try
            {
                var value = _memoryCache.Get("ExamType_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "ExamType_key",
                        value: await _mediator.Send(new GetAllExamTypesCommand()));
                }
                return Ok(_memoryCache.Get("ExamType_key") as List<ExamType>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteExamTypeAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteExamTypeCommand { Id = id });
                var value = _memoryCache.Get("ExamType_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamType_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateExamTypeByIdAsync([FromForm] UpdateExamTypeCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("ExamType_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamType_key");
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
                var res = await _mediator.Send(new GetByIdExamTypeCommand { Id = id });
                var value = _memoryCache.Get("ExamType_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamType_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
