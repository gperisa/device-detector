using DeviceDetector.Application.Queries;
using DeviceDetector.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceDetector.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class DeviceInfoController : ControllerBase
    {
        public static readonly IList<DeviceInfoResponse> deviceInfoHistory = new List<DeviceInfoResponse>();

        private readonly ILogger<DeviceInfoController> Logger;
        private readonly IMediator Mediator;

        public DeviceInfoController(ILogger<DeviceInfoController> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<DeviceInfoResponse> GetDeviceInfoAsync()
        {
            var userAgent = Request.Headers["User-Agent"].ToString();
            
            var query = new GetDeviceInfoQuery(userAgent);
            var result = await Mediator.Send(query);

            deviceInfoHistory.Add(result);

            return result;
        }

        [HttpPost]
        public IList<DeviceInfoResponse> SaveDeviceInfo(DeviceInfoResponse deviceInfo)
        {
            deviceInfoHistory.Add(deviceInfo);
            Logger.LogInformation("Device info was returned");
            return deviceInfoHistory;
        }
    }
}
