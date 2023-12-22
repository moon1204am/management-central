namespace DeviceApi.Services
{
    public interface IServiceManager
    {
        IDeviceService DeviceService { get; }
        ICityService CityService { get; }
    }
}