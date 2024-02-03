using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.ExamResults.Commands;
using School.Application.UseCases.ExamResults.Quarries;
using School.Application.UseCases.Exams.Commands;
using School.Application.UseCases.Exams.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamResultsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ExamResultsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateExamResultAsync(ExamResultDTO dto)
        {
            try
            {
                var command = new CreateExamResultCommand
                {
                    ExamId = dto.ExamId,
                    StudentId = dto.StudentId,
                    CourseId = dto.CourseId,
                    Marks = dto.Marks,
                };
                var value = _memoryCache.Get("ExamResult_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamResult_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllExamResultsAsync()
        {
            try
            {
                var value = _memoryCache.Get("ExamResult_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "ExamResult_key",
                        value: await _mediator.Send(new GetAllExamResultsCommand()));
                }
                return Ok(_memoryCache.Get("ExamResult_key") as List<ExamResult>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteExamResultAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteExamResultCommand { Id = id });
                var value = _memoryCache.Get("ExamResult_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamResult_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateExamResultByIdAsync([FromForm] UpdateExamResultCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("ExamResult_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamResult_key");
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
                var res = await _mediator.Send(new GetByIdExamResultCommand { Id = id });
                var value = _memoryCache.Get("ExamResult_key");
                if (value is not null)
                {
                    _memoryCache.Remove("ExamResult_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
