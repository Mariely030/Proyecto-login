using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Services.Network;
using SVE.Persistence.Repositories;

namespace SVE.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNetworkTypeDependencies(this IServiceCollection services)
        {
            services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();
            services.AddScoped<INetworkTypeService, NetworkTypeService>();
            services.AddScoped<INetworkProviderRepository, NetworkProviderRepository>();
            services.AddScoped<INetworkProviderService, NetworkProviderService>();

            return services;
        }
    }
}

