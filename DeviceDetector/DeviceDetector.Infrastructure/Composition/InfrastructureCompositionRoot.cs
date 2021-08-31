using Autofac;
using AutoMapper;
using DeviceDetector.Application.Abstractions;
using DeviceDetector.Application.Composition;
using DeviceDetector.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceDetector.Infrastructure.Composition
{
    public class InfrastructureCompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureCompositionRoot).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterDependentModules()
                .RegisterServices();
        }       
    }

    public static class InfrastructureCompositionRootExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddAutoMapper(GetAutoMapperProfilesFromAllAssemblies()
                .ToArray());

            services.AddApplication();
            return services;
        }

        public static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            var applicationAssembly = typeof(ApplicationCompositionRoot).Assembly;

            foreach (var aType in applicationAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Profile))))
            {
                yield return aType;
            }

            var infrastructureAssembly = typeof(InfrastructureCompositionRoot).Assembly;

            foreach (var aType in infrastructureAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Profile))))
            {
                yield return aType;
            }
        }

        internal static ContainerBuilder RegisterDependentModules(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationCompositionRoot>();
            return builder;
        }

        internal static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<DeviceDetectionService>()
                .As<IDeviceDetectionService>(); 

            return builder;
        }
    }
}
