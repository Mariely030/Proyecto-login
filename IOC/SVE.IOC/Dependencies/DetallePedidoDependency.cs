using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Interfaces;
using SVE.Application.Services;
using SVE.Application.Contracts.Repositories;
using SVE.Persistence.Repositories;

namespace SVE.IOC
{
    public static class DetallePedidoDependency
    {
        public static void AddDetallePedidoDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDetallePedidoService, DetallePedidoService>();
            services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
        }
    }
}
