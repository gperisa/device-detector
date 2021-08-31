using DeviceDetector.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceDetector.Application.UseCases.DeviceInfoUseCases
{
    public class GetDeviceInfoUseCase : IRequestHandler<GetDeviceInfoQuery>
    {
        private readonly IDeviceDetectionService _deviceDetectionService;
        //  private readonly ApplicationSettings _appSettings;

        public GetDeviceInfoUseCase(IDeviceDetectionService deviceDetectionService)
        {
            _deviceDetectionService = deviceDetectionService;
        }

        public async Task<DeviceInfoResponse> Handle(GetDeviceInfoQuery request, CancellationToken cancellationToken)
        {
            var response = return await _deviceDetectionService.GetDeviceInfo(request.UserAgent);
            
        }
    }
}
