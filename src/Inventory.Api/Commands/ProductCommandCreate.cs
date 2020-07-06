using Inventory.Abstraction.Models;
using System.Collections.Generic;
using MediatR;
using Inventory.Api.Mapper;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Commands
{
    public class ProductCommandCreate : IRequest<List<ProductModel>>
    {
        public ProductCommandCreate()
        {

        }

        public class ProductCommandCreateHandler : IRequestHandler<ProductCommandCreate, List<ProductModel>>
        {
            private readonly IInventoryContext _context;

            public ProductCommandCreateHandler(IInventoryContext context)
            {
                _context = context;
            }

            public async Task<List<ProductModel>> Handle(ProductCommandCreate request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();
                var models = new ProductMapper().Map(products);

                return models;
            }
        }
    }
}
