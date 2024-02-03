using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.DTOs;
using School.Application.UseCases.Attendances.Commands;
using School.Application.UseCases.Attendances.Quarries;
using School.Application.UseCases.Classrooms.Commands;
using School.Application.UseCases.Classrooms.Quarries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public AttendancesController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAttendanceAsync(AttendanceDTO dto)
        {
            try
            {
                var command = new CreateAttendanceCommand
                {
                    Date = dto.Date,
                    StudentId = dto.StudentId,
                    Status = dto.Status,
                    Description = dto.Description,
                };
                var value = _memoryCache.Get("Attendance_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Attendance_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAttendancesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Attendance_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Attendance_key",
                        value: await _mediator.Send(new GetAllAttendancesCommand()));
                }
                return Ok(_memoryCache.Get("Attendance_key") as List<Attendance>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAttendanceAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteAttendanceCommand { Id = id });
                var value = _memoryCache.Get("Attendance_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Attendance_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentByIdAsync([FromForm] UpdateAttendanceCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Attendance_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Attendance_key");
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
                var res = await _mediator.Send(new GetByIdAttendanceCommand { Id = id });
                var value = _memoryCache.Get("Attendance_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Attendance_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
