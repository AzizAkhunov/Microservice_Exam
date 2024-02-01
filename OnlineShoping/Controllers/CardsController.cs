using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoping.API.DTOs;
using OnlineShoping.Application.Absreactions;
using OnlineShoping.Application.UseCases.Cards.Commands;
using OnlineShoping.Application.UseCases.Cards.Quarries;
using OnlineShoping.Application.UseCases.Users.Commands;
using OnlineShoping.Application.UseCases.Users.Quarries;
using OnlineShoping.Domain.Entities;

namespace OnlineShoping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public CardsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCardAsync(CardDTO dto)
        {
            try
            {
                var command = new CreateCardsCommand
                {
                    CardNumber = dto.CardNumber,
                    Amount = dto.Amount,
                    UserId = dto.UserId
                };
                var value = _memoryCache.Get("Cards_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Cards_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCardsAsync()
        {
            //var res = await _mediator.Send(new GetAllUsersCommand());
            //return Ok(res);
            try
            {
                var value = _memoryCache.Get("Cards_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Cards_key",
                        value: await _mediator.Send(new GetAllCardsCommand()));
                }
                return Ok(_memoryCache.Get("Cards_key") as List<Card>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCardAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteCardsCommand { Id = id });
                var value = _memoryCache.Get("Cards_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Cards_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCardByIdAsync([FromForm] UpdateCardsCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Cards_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Cards_key");
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
                var res = await _mediator.Send(new GetByIdCardCommand { Id = id });
                var value = _memoryCache.Get("Cards_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Cards_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
