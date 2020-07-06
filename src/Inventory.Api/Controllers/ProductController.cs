using Inventory.Abstraction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ag2yd.Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        [Route("")]
        public List<ProductModel> Get()
        {
            return new List<ProductModel>();
        }
    }
}
