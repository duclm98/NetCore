using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using NetCore.API.Services;
using NetCore.API.SubServices;
using System.Linq;

namespace NetCore.API.Dependencies
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // AutoMapper
            builder.RegisterAutoMapper(typeof(Program).Assembly);

            // Sub Service
            builder.RegisterAssemblyTypes(typeof(UserSubService).Assembly)
                .Where(x => x.Name.EndsWith("SubService"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Service
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}