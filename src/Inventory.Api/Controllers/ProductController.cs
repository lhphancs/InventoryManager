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
    [Route("api/product/")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{upc}/")]
        public async Task<IActionResult> GetByUpc(string upc)
        {
            var productDto = await _mediator.Send(new ProductQueryGetByUpc(upc));
            return Ok(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productDtos = await _mediator.Send(new ProductQueryGetAll());
            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            await _mediator.Send(new ProductCommandCreate(productDto));
            return Ok();
        }

        [HttpPatch("{upc}/")]
        public async Task<IActionResult> UpdateInfo(string upc, [FromBody] ProductInfoDto productInfoDto)
        {
            await _mediator.Send(new ProductCommandUpdateInfo(upc, productInfoDto));
            return Ok();
        }

        [HttpPatch("{upc}/receive")]
        public async Task<IActionResult> Receive(string upc, [FromBody] ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            await _mediator.Send(new ProductCommandReceive(upc, productQuantityChangeInfo));
            return Ok();
        }

        [HttpDelete("{upc}/")]
        public async Task<IActionResult> Delete(string upc)
        {
            await _mediator.Send(new ProductCommandDelete(upc));
            return Ok();
        }
    }
}
