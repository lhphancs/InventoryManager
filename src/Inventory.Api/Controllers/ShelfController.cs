using Inventory.Abstraction.Dto;
using Inventory.Api.Commands;
using Inventory.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpPatch("{id}/add-shelf-product")]
        public async Task<IActionResult> AddShelfProduct(int id, [FromBody] ShelfProductDto shelfProductDto)
        {
            await _mediator.Send(new ShelfCommandAddShelfProduct(id, shelfProductDto.ProductId, shelfProductDto.Row, shelfProductDto.Position));
            return Ok();
        }

        [HttpPatch("{id}/delete-shelf-product/{sid}")]
        public async Task<IActionResult> DeleteShelfProduct(int id, [FromBody] List<int> shelfProductIds)
        {
            await _mediator.Send(new ShelfCommandDeleteShelfProducts(id, shelfProductIds));
            return Ok();
        }
    }
}
