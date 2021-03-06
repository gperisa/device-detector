using DeviceDetector.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDetector.Application.Queries
{
    public class GetDeviceInfoQuery : IRequest<DeviceInfoResponse>
    {
        public string UserAgent { get; }

        public GetDeviceInfoQuery(string userAgent)
        {
            UserAgent = userAgent;
        }
    }
}
