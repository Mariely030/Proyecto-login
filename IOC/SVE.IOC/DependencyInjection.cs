using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Contracts.Repositories.Insurance;
using SVE.Application.Contracts.Services.Insurance;
using SVE.Application.Services.Insurance;
using SVE.Persistence.Repositories;

namespace SVE.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNetworkTypeDependencies(this IServiceCollection services)
        {
            services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();
            services.AddScoped<INetworkTypeService, NetworkTypeService>();
            return services;
        }
    }
}

