using Microsoft.OpenApi.Models;
using System.Reflection;

namespace UsuariosApp.Services.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UsuarioApp - API para controle de usuários.",
                    Description = "API desenvolvida em .Net 7 com EF Core, XUNIT, JWT e RabbitMQ",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Renato Alves vasconcelos",
                        Email = "trunfo4608@gmail.com",
                        Url = new Uri("http://www.rav@solucoesltda.com.br")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }


        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosApp");
            });

            return app;
        }
    }
}
