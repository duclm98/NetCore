using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetCore.API.Dependencies;
using NetCore.API.Middlewares;
using NetCore.API.QueueService;
using NetCore.Data.Context;
using NetCore.Data.Repositories;
using NetCore.Helpers.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;

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
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
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

            // Config Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NetCore APIs",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer yourToken\""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer", Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
                c.EnableAnnotations();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "NetCore v1");
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
