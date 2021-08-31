using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceDetectorNET.Parser;
using GoranApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoranApp.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class DeviceInfoController : ControllerBase
    {
        public static readonly IList<DeviceInfo> deviceInfoHistory = new List<DeviceInfo>();

        private readonly ILogger<DeviceInfoController> _logger;

        public DeviceInfoController(ILogger<DeviceInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<DeviceInfo> GetDeviceInfo()
        {
            DeviceDetectorNET.DeviceDetector.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);

            var userAgent = Request.Headers["User-Agent"];
            var result = DeviceDetectorNET.DeviceDetector.GetInfoFromUserAgent(userAgent);

            var output = result.Success ? result.ToString().Replace(Environment.NewLine, "<br />") : "Unknown";
            return deviceInfoHistory;
        }

        [HttpPost]
        public IList<DeviceInfo> SaveDeviceInfo(DeviceInfo deviceInfo)
        {
            deviceInfoHistory.Add(deviceInfo);
            _logger.LogInformation("Device info was returned");
            return deviceInfoHistory;
        }
    }
}
