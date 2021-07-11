using Inventory.Abstraction.Dto;
using Inventory.Abstraction.Dto.Requests;
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
        public async Task<IActionResult> Create([FromBody] ShelfInfoDto shelfInfoDto)
        {
            var shelfDto = await _mediator.Send(new ShelfCommandCreate(shelfInfoDto));
            return Ok(shelfDto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInfo(int id, [FromBody] ShelfInfoDto shelfInfoDto)
        {
            var updatedShelfDto = await _mediator.Send(new ShelfCommandUpdateInfo(id, shelfInfoDto));
            return Ok(updatedShelfDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new ShelfCommandDelete(id));
            return Ok();
        }

        [HttpPost("{id}/shelf-product")]
        public async Task<IActionResult> CreateShelfProduct(int id, [FromBody] ShelfProductRequestDto request)
        {
            await _mediator.Send(new ShelfCommandCreateShelfProduct(id, request.ProductId, request.Row, request.Column));
            return Ok();
        }
    }
}
