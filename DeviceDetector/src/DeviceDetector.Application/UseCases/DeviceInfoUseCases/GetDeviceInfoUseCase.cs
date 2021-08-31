using AutoMapper;
using DeviceDetector.Application.Abstractions;
using DeviceDetector.Application.Queries;
using DeviceDetector.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceDetector.Application.UseCases.DeviceInfoUseCases
{
    public class GetDeviceInfoUseCase : IRequestHandler<GetDeviceInfoQuery, DeviceInfoResponse>
    {
        private readonly IDeviceDetectionService _deviceDetectionService;
        protected IMapper Mapper { get; }

        public GetDeviceInfoUseCase(IDeviceDetectionService deviceDetectionService, IMapper mapper)
        {
            _deviceDetectionService = deviceDetectionService;
            Mapper = mapper;
        }

        public async Task<DeviceInfoResponse> Handle(GetDeviceInfoQuery request, CancellationToken cancellationToken)
        {
            var response = await _deviceDetectionService.GetDeviceInfo(request.UserAgent);
            return Mapper.Map<DeviceInfoResponse>(response);
        }
    }
}

