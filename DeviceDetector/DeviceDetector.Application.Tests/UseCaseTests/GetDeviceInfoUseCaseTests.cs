using AutoMapper;
using DeviceDetector.Application.Abstractions;
using DeviceDetector.Application.Queries;
using DeviceDetector.Application.UseCases.DeviceInfoUseCases;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DeviceDetector.Application.Tests.UseCaseTests
{
    public class GetDeviceInfoUseCaseTests
    {
        public IMapper Mapper { get; set; }
        const string userAgent = "Mozzzzila";

        [Fact]
        public async Task GetDeviceInfoUseCase_SuccessTest()
        {
            // -- Arrange
            var mapper = new MapperFixture();

            Mapper = mapper.CreateMapper();

            var deviceDetectionService = Substitute.For<IDeviceDetectionService>();

            var useCase = new GetDeviceInfoUseCase(deviceDetectionService, Mapper);

            // -- Act
            var cmd = new GetDeviceInfoQuery(userAgent);

            var result = await useCase.Handle(cmd, CancellationToken.None);

            // -- Assert
            Assert.NotNull(result);
        }


        [Fact]
        public async Task GetDeviceInfoUseCase_FailTest()
        {
            // -- Arrange
            var mapper = new MapperFixture();

            Mapper = mapper.CreateMapper();

            var deviceDetectionService = Substitute.For<IDeviceDetectionService>();

            var useCase = new GetDeviceInfoUseCase(deviceDetectionService, Mapper);

            // -- Act
            var cmd = new GetDeviceInfoQuery(userAgent);

            var result = await useCase.Handle(cmd, CancellationToken.None);

            // -- Assert
        }
    }
}
