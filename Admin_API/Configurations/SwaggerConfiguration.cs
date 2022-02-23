using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Admin_API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            //Configuração da documentação da API (Swagger)
            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo 
                    {
                        Title = "API Políticos",
                        Description = "Projeto API REST desenvolvida em ASP.NET Core 5.0 - Desenvolvido por Natália Sousa",
                        Version = "v1",
                        Contact = new OpenApiContact 
                        {
                            Name = "Projeto_Desafio_API",
                            Url = new System.Uri("https://gilsondelazari.files.wordpress.com/2018/02/27867295_407293079717277_2598523447132156036_n.jpg?w=720"),
                            Email = "startergft@gft.com"
                        }
                    });
                    
                    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()  
                {  
                    Name = "Authorization",  
                    Type = SecuritySchemeType.ApiKey,  
                    Scheme = "Bearer",  
                    BearerFormat = "JWT",  
                    In = ParameterLocation.Header,  
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",  
                });  
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement  
                {  
                    {  
                          new OpenApiSecurityScheme  
                            {  
                                Reference = new OpenApiReference  
                                {  
                                    Type = ReferenceType.SecurityScheme,  
                                    Id = "Bearer"  
                                }  
                            },  
                            new string[] {}  
  
                    }  
                });  
                }
            );
            
        }

    }
}