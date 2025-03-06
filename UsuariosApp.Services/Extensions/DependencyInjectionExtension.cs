using UsuarioApp.Domain.Interfaces;
using UsuarioApp.Domain.Interfaces.Messages;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
//using UsuarioApp.Domain.Messages;
using UsuarioApp.Domain.Services;
using UsuarioApp.Infra.Data.Respositories;
using UsuarioApp.Infra.Security;
using UsuariosApp.Aplication.Interface;
using UsuariosApp.Aplication.Service;
using UsuariosApp.Infra.Messages.Consumers;
using UsuariosApp.Infra.Messages.Messages;

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
            services.AddTransient<IEmailMessageProducer, EmailMessageProducer>();

            services.AddHostedService<EmailMessageConsumer>();
            return services; 
        }
    }
}
