using Microsoft.Extensions.DependencyInjection;

namespace SVE.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registro modular por entidad
            services.AddUsuarioDependencies();
            services.AddProductoDependencies();
            services.AddPedidoDependencies();
            services.AddDetallePedidoDependencies();
            services.AddPromocionDependencies();
        }
    }
}
