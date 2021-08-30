using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
