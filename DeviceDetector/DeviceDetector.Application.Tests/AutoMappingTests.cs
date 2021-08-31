using AutoMapper;
using DeviceDetector.Application.Mapping;
using Xunit;

namespace DeviceDetector.Application.Tests
{
    public class AutoMappingTests
    {
        [Fact]
        public void VerifyDepositProfileMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DeviceInfoProfile());
            });
            config.AssertConfigurationIsValid();
        }
    }
}
