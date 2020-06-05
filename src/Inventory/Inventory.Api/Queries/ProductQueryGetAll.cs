using Inventory.Abstraction.Models;
using System.Collections.Generic;
using MediatR;
using Inventory.Api.Mapper;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Inventory.Api.Aggregates;

namespace Inventory.Api.Queries
{
    public class ProductQueryGetAll : IRequest<List<ProductModel>>
    {
        public ProductQueryGetAll()
        {

        }

        public class ProductGetAllQueryHandler : IRequestHandler<ProductQueryGetAll, List<ProductModel>>
        {
            private readonly IInventoryContext _context;
            private readonly IProductMapper _productMapper;

            public ProductGetAllQueryHandler(IInventoryContext context, IProductMapper productMapper)
            {
                _context = context;
                _productMapper = productMapper;
            }

            public async Task<List<ProductModel>> Handle(ProductQueryGetAll request, CancellationToken cancellationToken)
            {
                var products = _context.Products.ToList();
                var models = await _productMapper.MapAsync<IEnumerable<Product>, List<ProductModel>>(products);

                return models;
            }
        }
    }
}
