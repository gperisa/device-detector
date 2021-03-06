using DeviceDetector.Domain;
using DeviceDetector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDetector.Application.Abstractions
{
    public interface IDeviceDetectionService
    {
        Task<DeviceInfo> GetDeviceInfo(string UserAgent); 
    }
}
