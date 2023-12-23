using ManagementCentral.Shared.Domain;

namespace DeviceApi.Services
{
    public interface IDeviceService
    {
        Task<Device> AddDeviceAsync(Device device);
        Task DeleteDeviceAsync(int deviceId);
        Task<Device?> GetDeviceAsync(int deviceId);
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task UpdateDeviceAsync(Device device);
    }
}