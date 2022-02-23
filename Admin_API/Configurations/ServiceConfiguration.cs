using Admin_Dominio.Interfaces.IServices;
using Admin_Dominio.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Admin_API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddConfigureService(this IServiceCollection services) // this -> pegar o mesmo IServiceCollection 
        {   
            services.AddScoped<IDeputadoService, DeputadoService>();
            services.AddScoped<IGovernadorService, GovernadorService>();
            services.AddScoped<IMinistroService, MinistroService>();
            services.AddScoped<IPrefeitoService, PrefeitoService>();
            services.AddScoped<IPresidenteService, PresidenteService>();
            services.AddScoped<ISenadorService, SenadorService>();
            services.AddScoped<IVereadorService, VereadorService>();
        }
    }
}