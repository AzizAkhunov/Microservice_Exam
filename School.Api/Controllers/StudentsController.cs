using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public StudentsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentAsync(StudentDTO dto)
        {
            try
            {
                var command = new CreateStudentCommand
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Name = dto.Name,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                    ParentId = dto.ParentId,
                };
                var value = _memoryCache.Get("Student_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Student_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllStudentsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Student_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Student_key",
                        value: await _mediator.Send(new GetAllStudentsCommand()));
                }
                return Ok(_memoryCache.Get("Student_key") as List<Student>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteStudentCommand { Id = id });
                var value = _memoryCache.Get("Student_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Student_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentByIdAsync([FromForm] UpdateStudentCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Student_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Student_key");
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
                var res = await _mediator.Send(new GetByIdStudentCommand { Id = id });
                var value = _memoryCache.Get("Student_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Student_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
