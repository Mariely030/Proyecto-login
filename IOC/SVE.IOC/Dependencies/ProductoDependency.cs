using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Interfaces;
using SVE.Application.Services;
using SVE.Application.Contracts.Repositories;
using SVE.Persistence.Repositories;

namespace SVE.IOC
{
    public static class ProductoDependency
    {
        public static void AddProductoDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
        }
    }
}
