using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieLibrary.Data.Extension;
using MovieLibrary.Data;
using System;
using System.Linq;
using System.Reflection;
using MovieLibrary.Data.Repositories;
using MovieLibrary.Core.Services.Categories;

namespace MovieLibrary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            var coreAssembly = Assembly.Load("MovieLibrary.Core");
            var dataAssembly = Assembly.Load("MovieLibrary.Data");

            var dependencyTypes = coreAssembly.GetTypes()
                .Concat(dataAssembly.GetTypes())
                .Where(type => typeof(IDependency).IsAssignableFrom(type) && !type.IsInterface);

            foreach (var dependencyType in dependencyTypes)
            {
                var interfaceType = dependencyType.GetInterfaces()
                    .FirstOrDefault(type => type != typeof(IDependency));

                if (interfaceType != null)
                {
                    services.AddTransient(interfaceType, dependencyType);
                }
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<MovieLibraryContext>();

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie library API", Version = "v1" });
            });

            RegisterDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie library API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
