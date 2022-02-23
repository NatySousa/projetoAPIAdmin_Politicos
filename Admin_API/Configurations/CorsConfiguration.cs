using Microsoft.Extensions.DependencyInjection;

namespace Admin_API.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfigure(this IServiceCollection services) 
        {
            //Configuração do Cors - Cross Origin Resource Sharing
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy", builder =>
                {
                    //permitindo que qualquer servidor faça requisições para a API
                    builder.AllowAnyOrigin()
                    //permitindo que qualquer método da API seja executado(Post, Put, Get, Delete, etc)
                    .AllowAnyMethod()
                    //permitindo que qualquer cabeçalho seja enviado para a API(Token por exemplo)
                    .AllowAnyHeader();

   
                })); 
                
        }
    }
}