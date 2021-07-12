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
    [Route("wholesaler/")]
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
        public async Task<IActionResult> GetAllByProductId([FromQuery] int productId)
        {
            var WholesalerDtos = await _mediator.Send(new WholesalerQueryGetAll(productId));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new WholesalerCommandDelete(id));
            return Ok();
        }

        [HttpPost("{id}/add-products")]
        public async Task<IActionResult> AddProducts(int id, [FromBody] List<int> productIds)
        {
            var wholesaler = await _mediator.Send(new WholesalerCommandAddProducts(id, productIds));
            return Ok(wholesaler);
        }

        [HttpDelete("{id}/delete-products")]
        public async Task<IActionResult> RemoveProducts(int id, [FromBody] List<int> productIds)
        {
            var wholesaler = await _mediator.Send(new WholesalerCommandDeleteProducts(id, productIds));
            return Ok(wholesaler);
        }
    }
}
