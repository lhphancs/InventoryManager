using Ag2yd.Inventory.Api.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Inventory.Api.Infrastructure
{
    public static class DependencyBuilder
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration) {
            RegisterMapper(services);
        }

        private static void RegisterMapper(IServiceCollection services)
        {
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IShelfLocationMapper, ShelfLocationMapper>();
        }
    }
}
