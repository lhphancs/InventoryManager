using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ag2yd.Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return null;
        }

        [HttpPost]
        public void Create([FromBody] Product product)
        {
            
        }
    }
}
