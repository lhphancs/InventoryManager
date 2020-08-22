using Inventory.Abstraction.Dto;
using Inventory.Api.Commands;
using Inventory.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll()
        {
            var WholesalerDtos = await _mediator.Send(new WholesalerQueryGetAll());
            return Ok(WholesalerDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WholesalerInfoDto wholesalerInfoDto)
        {
            await _mediator.Send(new WholesalerCommandCreate(wholesalerInfoDto));
            return Ok();
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

        [HttpPost("{id}/add-product/{pid}")]
        public async Task<IActionResult> AddProduct(int id, int pid)
        {
            await _mediator.Send(new WholesalerCommandAddProduct(id, pid));
            return Ok();
        }

        [HttpDelete("{id}/remove-product/{pid}")]
        public async Task<IActionResult> RemoveProduct(int id, int pid)
        {
            await _mediator.Send(new WholesalerCommandRemoveProduct(id, pid));
            return Ok();
        }
    }
}
