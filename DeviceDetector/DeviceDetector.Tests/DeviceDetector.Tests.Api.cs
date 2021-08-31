using DeviceDetector.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeviceDetector.Tests.Api
{
    public class ApiTests
    {
        private readonly HttpClient _testClient;

        public ApiTests(HttpClient client)
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
        }

        [Fact]
        public async Task PostDeviceInfoTest()
        { 
            // -- Arrange
            var deviceInfo = new DeviceInfo()
            {
               Browser = "Chrome",
               BrowserVersion = "11",
               Device = "Test device",
               OS = "Windows",
               DeviceType = "sdsad",
               Orientation = "portrait",
               OsVersion = "OS v1",
               UserAgent = "Mpzzila"
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(deviceInfo),Encoding.UTF8, "application/json");

            // -- Act
            var response = await _testClient.PostAsync($"/deviceInfo", httpContent);

            // -- Assert
            Assert.NotNull(response);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsJsonAsync<List<DeviceInfo>>()
                    .ConfigureAwait(false);
                Assert.Single(result);
                Assert.Equal("11", result[0].BrowserVersion);
            }
        }
    }
}
