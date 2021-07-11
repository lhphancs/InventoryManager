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
    [Route("product/")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _mediator.Send(new ProductQueryGetById(id));
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productDtos = await _mediator.Send(new ProductQueryGetAll());
            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductInfoDto productInfoDto)
        {
            var product = await _mediator.Send(new ProductCommandCreate(productInfoDto));
            return Ok(product);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInfo(int id, [FromBody] ProductInfoDto productInfoDto)
        {
            var updatedProductDto = await _mediator.Send(new ProductCommandUpdateInfo(id, productInfoDto));
            return Ok(updatedProductDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new ProductCommandDelete(id));
            return Ok();
        }

        [HttpPatch("receive")]
        public async Task<IActionResult> Receive([FromBody] ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            var productDto = await _mediator.Send(new ProductCommandReceive(productQuantityChangeInfo));
            return Ok(productDto);
        }

    }
}
