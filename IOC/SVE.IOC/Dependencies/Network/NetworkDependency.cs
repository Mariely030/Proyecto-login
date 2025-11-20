using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Services.Network;
using SVE.Persistence.Repositories;

namespace SVE.IOC.Dependencies.Network
{
    public static class NetworkDependency
    {
        public static void AddNetworkDependencies(this IServiceCollection services)
        {

            services.AddScoped<INetworkProviderRepository, NetworkProviderRepository>();
            services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();

            services.AddScoped<INetworkProviderService, NetworkProviderService>();
            services.AddScoped<INetworkTypeService, NetworkTypeService>();
        }
    }
}
 