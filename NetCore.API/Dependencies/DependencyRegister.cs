using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using NetCore.API.Services;
using System.Linq;

namespace NetCore.API.Dependencies
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // AutoMapper
            builder.RegisterAutoMapper(typeof(Program).Assembly);

            // Service
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}