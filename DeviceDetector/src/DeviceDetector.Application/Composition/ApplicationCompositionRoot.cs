using Autofac;
using DeviceDetector.Application.Queries;
using DeviceDetector.Application.UseCases.DeviceInfoUseCases;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDetector.Application.Composition
{
    public class ApplicationCompositionRoot : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationCompositionRoot).GetTypeInfo()
                      .Assembly)
                       .AsImplementedInterfaces();

            builder
            .RegisterUseCaseAggregate();
        }
    }

    public static class ApplicationCompositionRootExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationCompositionRootExtensions));
      
            return services;
        }

        internal static ContainerBuilder RegisterUseCaseAggregate(this ContainerBuilder builder)
        {
            builder.RegisterType<GetDeviceInfoUseCase>().As<GetDeviceInfoUseCase>();
            return builder;
        }
    }
}
