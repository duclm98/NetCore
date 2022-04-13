using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.API.Dependencies;
using NetCore.API.Helpers;
using NetCore.API.Middlewares;
using NetCore.API.QueueService;
using NetCore.Data.Context;
using NetCore.Data.Repositories;
using NetCore.Helpers.Exceptions;
using Newtonsoft.Json;
using System.Linq;

namespace NetCore.API
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
            //var connectionString = Configuration.GetConnectionString("MSSQLConnection");
            //services.AddDbContext<NetCoreDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            var connectionString = Configuration.GetConnectionString("PostgreSQLConnection");
            services.AddDbContext<NetCoreDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue>(_ =>
            {
                if (!int.TryParse(Configuration["QueueCapacity"], out var queueCapacity))
                {
                    queueCapacity = 100;
                }

                return new DefaultBackgroundTaskQueue(queueCapacity);
            });
            services.AddSingleton<MonitorLoop>();
            services.AddSingleton<UnitOfWork>();

            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyHeader();
                config.AllowAnyMethod();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                provider.ApiVersionDescriptions.ToList().ForEach(description =>
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                });
            });
            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
