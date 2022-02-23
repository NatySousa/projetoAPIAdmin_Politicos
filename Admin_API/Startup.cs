using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Configurations;
using Admin_Infraestrutura.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


namespace Projeto_desafio_API_Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // Caminho para conectar ao banco no Mysql 
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),  b => b.MigrationsAssembly("Projeto_desafio_API_Admin")));//passando outro parâmetro para criar a migrations

            services.AddControllers();

            services.AddSwaggerGen();
            
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddSwaggerConfiguration();

            services.AddConfigureRepository(); 
                      
            services.AddConfigureService();           

            services.AddJWTConfigure(Configuration);   

            services.AddCorsConfigure();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto_desafio_API_Admin v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
