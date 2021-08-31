using Autofac;
using AutofacSerilogIntegration;
using DeviceDetector.Infrastructure.Composition;

namespace DeviceDetector.Api.Composition
{
    public class WebCompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            builder.RegisterModule<InfrastructureCompositionRoot>();
        }
    }
}
