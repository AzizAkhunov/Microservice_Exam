using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Courses.Commands;
using School.Application.UseCases.Courses.Quarries;
using School.Application.UseCases.Grades.Commands;
using School.Application.UseCases.Grades.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public CoursesController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCourseAsync(CourseDTO dto)
        {
            try
            {
                var command = new CreateCourseCommand
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    GradeId = dto.GradeId,
                };
                var value = _memoryCache.Get("Course_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Course_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCoursesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Course_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Course_key",
                        value: await _mediator.Send(new GetAllCoursesCommand()));
                }
                return Ok(_memoryCache.Get("Course_key") as List<Course>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCourseAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteCourseCommand { Id = id });
                var value = _memoryCache.Get("Course_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Course_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCourseByIdAsync([FromForm] UpdateCourseCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Course_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Course_key");
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
                var res = await _mediator.Send(new GetByIdCourseCommand { Id = id });
                var value = _memoryCache.Get("Course_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Course_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
