using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using Inventory.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            await _mediator.Send(new ProductCommandCreate(productDto));
            return Ok();
        }

        [HttpPatch("{upc}/")]
        public async Task<IActionResult> Update(string upc, [FromBody] ProductDto productDto)
        {
            await _mediator.Send(new ProductCommandUpdate(upc, productDto));
            return Ok();
        }
    }
}
