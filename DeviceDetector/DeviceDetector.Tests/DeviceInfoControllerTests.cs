using DeviceDetector.Domain;
using DeviceDetector.Models;
using DeviceDetector.Tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeviceDetector.Api.Tests
{
    public class DeviceInfoControllerTests
    {
        private readonly HttpClient _testClient;

        public DeviceInfoControllerTests(HttpClient client)
        {
            _testClient = client;
        }

        [Fact]
        public async Task GetDeviceInfoTest()
        {
            // -- Arrange

            // -- Act
            var result = await _testClient.GetAsync($"/deviceInfo");

            // -- Assert
            Assert.NotNull(result);
            Assert.IsType<DeviceInfoResponse>(result);
        }

        [Fact]
        public async Task SaveDeviceInfoTest()
        {
            // -- Arrange
            var deviceInfo = new DeviceInfoResponse()
            {
                Browser = "Chrome",
                BrowserVersion = "11",
                Device = "Test device",
                OS = "Windows",
                DeviceType = "sdsad",
                OsVersion = "OS v1",
                UserAgent = "Mpzzila"
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(deviceInfo), Encoding.UTF8, "application/json");

            // -- Act
            var response = await _testClient.PostAsync($"/deviceInfo", httpContent);

            // -- Assert
            Assert.NotNull(response);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsJsonAsync<List<DeviceInfoResponse>>()
                    .ConfigureAwait(false);
                Assert.Single(result);
                Assert.Equal("11", result[0].BrowserVersion);
            }
        }
    }
}
