using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.IO;
using TemperatureProject.Infrastructure;
using Autofac;
using MediatR;
using TemperatureProject.Contract.Query;
using TemperatureProject.Domain.Interfaces;
using TemperatureProject.Infrastructure.Repositories;
using TemperatureProject.Core.Configuration;
using TemperatureProject.Database;
using Microsoft.EntityFrameworkCore;
using TemperatureProject.Domain.Services.Interfaces;
using TemperatureProject.Domain.Services;

namespace TemperatureProject
{
    public class Startup
    {
        private const string ApiName = "Temperature Project";

 //       private readonly Lazy<TemperatureProjectSettings> _lazySettings;

        public IConfiguration Configuration { get; }


 //       public TemperatureProjectSettings Settings => _lazySettings.Value;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
  //          _lazySettings = new Lazy<TemperatureProjectSettings>(() => configuration.Get<TemperatureProjectSettings>());
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddSwaggerGen(options => 
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.AddControllers();
            services.AddOptions();
            var assembly = AppDomain.CurrentDomain.Load("TemperatureProject.Handlers");
            services.AddMediatR(assembly);

            services.AddTransient<ITemperatureDatabaseRepository, TemperatureDatabaseRepository>();
            services.AddTransient<ITemperatureProjectService, TemperatureProjectService>();

            services.AddSingleton(Configuration.GetSection("LocalDatabaseConfiguration").Get<LocalSettings>());
            var connectionString = Configuration["LocalDatabaseConfiguration:MyConnection"];
            services.AddDbContext<TemperatureProjectDbContext>
                (options => {
                    options.UseSqlServer(connectionString, optionsBuilder => optionsBuilder.MigrationsAssembly("TemperatureProject.Database"));
                });
            //           var containerBuilder = new ContainerBuilder();
            //           ConfigureContainer(containerBuilder);
        }

//        public void ConfigureContainer(ContainerBuilder builder)
//        {
 //           builder.RegisterModule(new InfrastructureModule(Settings));
 //       }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TemperatureProjectDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/errors");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            db.Database.Migrate();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = String.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

 //           app.UseEndpoints(endpoints =>
 //           {
 //               endpoints.MapRazorPages();
 //           });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
