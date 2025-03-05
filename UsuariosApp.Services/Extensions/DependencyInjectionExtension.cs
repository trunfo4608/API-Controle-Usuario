using UsuarioApp.Domain.Interfaces;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Domain.Services;
using UsuarioApp.Infra.Data.Respositories;
using UsuarioApp.Infra.Security;
using UsuariosApp.Aplication.Interface;
using UsuariosApp.Aplication.Service;

namespace UsuariosApp.Services.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainServices>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IHistoricoAtividadeRepository, HistoricoAtividadeRepository>();
            services.AddTransient<ITokenSecurity, TokenSecurity>();

            return services; 
        }
    }
}
