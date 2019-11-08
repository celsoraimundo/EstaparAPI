using Estapar.Domain.Entities;
using Estapar.Infra.Data.Context;
using Estapar.Infra.Data.Repository;
using Estapar.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Estapar.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Estapar", Version = "v1" });
            });

            services.AddDbContext<essenceestaparContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EssenceEstaparDatabase"));
            }, ServiceLifetime.Scoped);

            services.AddScoped<BaseService<Manobrista>>();
            services.AddScoped<BaseService<Veiculo>>();
            services.AddScoped<BaseService<VeiculoManobra>>();
            services.AddScoped<BaseRepository<Manobrista>>();
            services.AddScoped<BaseRepository<Veiculo>>();
            services.AddScoped<BaseRepository<VeiculoManobra>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Estapar V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}