namespace DeviceApi.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDeviceService> _deviceService;
        public IDeviceService DeviceService => _deviceService.Value;

        private readonly Lazy<ICityService> _cityService;
        public ICityService CityService => _cityService.Value;

        public ServiceManager(Lazy<IDeviceService> deviceService, Lazy<ICityService> cityService)
        {
            _deviceService = deviceService;
            _cityService = cityService;
        }
    }
}
