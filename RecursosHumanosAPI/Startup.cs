using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecursosHumanosAPI.Controllers;
using RecursosHumanosAPI.Models;
using AutoMapper;

namespace RecursosHumanosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RecursosHumanosDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RecursosHumanosDB")), ServiceLifetime.Scoped);

            // Configuración de AutoMapper
            AutoMapperConfiguration.Configure(services);

            // Otros servicios y configuraciones...
            services.AddTransient<BeneficiosController>();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuraciones de middleware...

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecursosHumanosAPI V1");
            });

            // Más configuraciones de middleware...
        }
    }
}
