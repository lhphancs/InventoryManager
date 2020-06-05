using Inventory.Abstraction.Models;
using System.Collections.Generic;
using MediatR;
using Inventory.Api.Mapper;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Inventory.Api.Aggregates;

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
            private readonly IProductMapper _productMapper;

            public ProductCommandCreateHandler(IInventoryContext context, IProductMapper productMapper)
            {
                _context = context;
                _productMapper = productMapper;
            }

            public async Task<List<ProductModel>> Handle(ProductCommandCreate request, CancellationToken cancellationToken)
            {
                var products = _context.Products.ToList();
                var models = await _productMapper.MapAsync<IEnumerable<Product>, List<ProductModel>>(products);

                return models;
            }
        }
    }
}
