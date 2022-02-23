using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Admin_API.Configurations
{
    public static class RepositoryConfiguration
    {
         public static void AddConfigureRepository(this IServiceCollection services) // this -> pegar o mesmo IServiceCollection 
        {   
            services.AddScoped<IDeputadoRepository, DeputadoRepository>();
            services.AddScoped<IGovernadorRepository, GovernadorRepository>();
            services.AddScoped<IMinistroRepository, MinistroRepository>();
            services.AddScoped<IPrefeitoRepository, PrefeitoRepository>();
            services.AddScoped<IPresidenteRepository, PresidenteRepository>();
            services.AddScoped<ISenadorRepository, SenadorRepository>();
            services.AddScoped<IVereadorRepository, VereadorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}