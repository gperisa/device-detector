using DeviceDetector.Application.Abstractions;
using DeviceDetector.Domain;
using DeviceDetectorNET.Parser;
using System.Threading.Tasks;
using DetectorLib = DeviceDetectorNET.DeviceDetector;

namespace DeviceDetector.Infrastructure.Services
{
    public class DeviceDetectionService : IDeviceDetectionService
    {
        public async Task<DeviceInfo> GetDeviceInfo(string userAgent)
        {
            DetectorLib.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);

            var detectionResponse = new DetectorLib(userAgent);

            detectionResponse.Parse();

            var deviceInfo = new DeviceInfo()
            {
                Browser = detectionResponse.GetBrowserClient().Match.Name,
                BrowserVersion = detectionResponse.GetBrowserClient().Match.Version,
                Device = detectionResponse.GetDeviceName(),
                DeviceType = detectionResponse.GetModel(),
                OS = detectionResponse.GetOs().Match.Name,
                OsVersion = detectionResponse.GetOs().Match.Version,
                UserAgent = userAgent
            };

            return await Task.FromResult(deviceInfo);
        }
    }
}
