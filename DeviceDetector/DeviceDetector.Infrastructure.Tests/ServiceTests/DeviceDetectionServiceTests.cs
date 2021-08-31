using DeviceDetector.Infrastructure.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeviceDetector.Infrastructure.Tests.ServiceTests
{
    public class DeviceDetectionServiceTests
    {
        const string userAgent = "Mozzzzila";

        [Fact]
        public async Task DeviceDetectionService_GetDeviceInfo()
        {
            // -- Arrange
            var service = new DeviceDetectionService();
            var deviceDetectorLib = Substitute.For<DeviceDetectorNET.DeviceDetector>();

            // TODO: To test service prperly, DeviceDetectorNET.DeviceDetector needs to be added by dependency injection in service

            // -- Act
            await service.GetDeviceInfo(userAgent);

            // -- Assert

        }
    }
}
