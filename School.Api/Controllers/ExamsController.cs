using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Classrooms.Commands;
using School.Application.UseCases.Classrooms.Quarries;
using School.Application.UseCases.Exams.Commands;
using School.Application.UseCases.Exams.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ExamsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateExamAsync(ExamDTO dto)
        {
            try
            {
                var command = new CreateExamCommand
                {
                    ExamTypeId = dto.ExamTypeId,
                    Name = dto.Name,
                };
                var value = _memoryCache.Get("Exam_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Exam_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllExamsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Exam_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Exam_key",
                        value: await _mediator.Send(new GetAllExamsCommand()));
                }
                return Ok(_memoryCache.Get("Exam_key") as List<Exam>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteExamAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteExamCommand { Id = id });
                var value = _memoryCache.Get("Exam_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Exam_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentByIdAsync([FromForm] UpdateExamCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Exam_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Exam_key");
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
                var res = await _mediator.Send(new GetByIdExamCommand { Id = id });
                var value = _memoryCache.Get("Exam_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Exam_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
