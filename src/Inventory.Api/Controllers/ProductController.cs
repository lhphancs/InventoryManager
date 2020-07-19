using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates;
using Inventory.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ag2yd.Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
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
        public async Task<IActionResult> Create([FromBody] ProductInformation model)
        {
            await _mediator.Send(new ProductCommandCreate(model));
            return Ok();
        }
    }
}
