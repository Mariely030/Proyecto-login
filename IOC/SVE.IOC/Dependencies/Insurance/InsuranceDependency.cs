using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Contracts.Repositories.Insurance;
using SVE.Application.Contracts.Services.Insurance;
using SVE.Application.Services.Insurance;
using SVE.Persistence.Repositories;

namespace SVE.IOC.Dependencies.Insurance
{
    public static class InsuranceDependency
    {
        public static void AddInsuranceDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IInsuranceProviderRepository, InsuranceProviderRepository>();
            services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();

            // Services
            services.AddScoped<IInsuranceProviderService, InsuranceProviderService>();
            services.AddScoped<INetworkTypeService, NetworkTypeService>();
        }
    }
}
