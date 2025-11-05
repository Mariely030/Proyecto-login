using Microsoft.Extensions.DependencyInjection;
using SVE.Application.Interfaces;
using SVE.Application.Services;
using SVE.Application.Contracts.Repositories;
using SVE.Persistence.Repositories;

namespace SVE.IOC
{
    public static class UsuarioDependency
    {
        public static void AddUsuarioDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
