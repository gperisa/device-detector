using AutoMapper;
using DeviceDetector.Domain;
using DeviceDetector.Models;

namespace DeviceDetector.Application.Mapping
{
    public class DeviceInfoProfile : Profile
    {
        public DeviceInfoProfile()
        {
            CreateMap<DeviceInfo, DeviceInfoResponse>();
        }
    }
}
