using Inventory.Abstraction.Dto;
using Inventory.Api.Commands;
using Inventory.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ag2yd.Inventory.Api.Controllers
{
    [ApiController]
    [Route("shelf/")]
    public class ShelfController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var shelfDto = await _mediator.Send(new ShelfQueryGetById(id));
            return Ok(shelfDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shelfDtos = await _mediator.Send(new ShelfQueryGetAll());
            return Ok(shelfDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShelfDto shelfDto)
        {
            await _mediator.Send(new ShelfCommandCreate(shelfDto));
            return Ok();
        }

        [HttpDelete("{id}/")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new ShelfCommandDelete(id));
            return Ok();
        }

        [HttpPut("{id}/add-shelf-location")]
        public async Task<IActionResult> Receive(int shelfId, [FromBody] ShelfLocationDto shelfLocationDto)
        {
            await _mediator.Send(new ShelfCommandAddShelfLocation(shelfId, shelfLocationDto.Row, shelfLocationDto.Position));
            return Ok();
        }
    }
}
