using Inventory.Abstraction.Dto;
using Inventory.Api.Commands;
using Inventory.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("Wholesaler/")]
    public class WholesalerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WholesalerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var WholesalerDto = await _mediator.Send(new WholesalerQueryGetById(id));
            return Ok(WholesalerDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string upc)
        {
            var WholesalerDtos = await _mediator.Send(new WholesalerQueryGetAll(upc));
            return Ok(WholesalerDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WholesalerInfoDto wholesalerInfoDto)
        {
            var wholesaler = await _mediator.Send(new WholesalerCommandCreate(wholesalerInfoDto));
            return Ok(wholesaler);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInfo(int id, [FromBody] WholesalerInfoDto wholesalerInfoDto)
        {
            var updatedWholesalerDto = await _mediator.Send(new WholesalerCommandUpdateInfo(id, wholesalerInfoDto));
            return Ok(updatedWholesalerDto);
        }

        [HttpDelete("{id}/")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new WholesalerCommandDelete(id));
            return Ok();
        }

        [HttpPost("{id}/add-products")]
        public async Task<IActionResult> AddProducts(int id, [FromBody] List<string> upcs)
        {
            var wholesaler = await _mediator.Send(new WholesalerCommandAddProducts(id, upcs));
            return Ok(wholesaler);
        }

        [HttpDelete("{id}/remove-product")]
        public async Task<IActionResult> RemoveProduct(int id, [FromBody] List<string> upcs)
        {
            var wholesaler = await _mediator.Send(new WholesalerCommandRemoveProducts(id, upcs));
            return Ok(wholesaler);
        }
    }
}
