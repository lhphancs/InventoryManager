using Inventory.Abstraction.Dto;
using Inventory.Api.Commands;
using Inventory.Api.Queries;
using Inventory.Api.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ag2yd.Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/shelf/")]
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
            var productDto = await _mediator.Send(new ProductQueryGetById(id));
            return Ok(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shelfDtos = await _mediator.Send(new ShelfQueryGetAll());
            return Ok(shelfDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            await _mediator.Send(new ProductCommandCreate(productDto));
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInfo(int id, [FromBody] ProductInfoDto productInfoDto)
        {
            await _mediator.Send(new ProductCommandUpdateInfo(id, productInfoDto));
            return Ok();
        }

        [HttpPatch("receive")]
        public async Task<IActionResult> Receive([FromBody] ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            await _mediator.Send(new ProductCommandReceive(productQuantityChangeInfo));
            return Ok();
        }

        [HttpDelete("{id}/")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new ProductCommandDelete(id));
            return Ok();
        }
    }
}
