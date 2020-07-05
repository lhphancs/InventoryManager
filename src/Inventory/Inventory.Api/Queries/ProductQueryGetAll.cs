using Inventory.Abstraction.Models;
using System.Collections.Generic;
using MediatR;
using Inventory.Api.Mapper;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            public ProductGetAllQueryHandler(IInventoryContext context)
            {
                _context = context;
            }

            public async Task<List<ProductModel>> Handle(ProductQueryGetAll request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();
                var models = new ProductMapper().Map(products);

                return models;
            }
        }
    }
}
