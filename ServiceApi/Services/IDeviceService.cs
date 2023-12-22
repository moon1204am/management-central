using ManagementCentral.Shared.Domain;

namespace DeviceApi.Services
{
    public interface IDeviceService
    {
        Task AddDeviceAsync(Device device);
        void DeleteDeviceAsync(int deviceId);
        Task<Device?> GetDeviceAsync(int deviceId);
        Task<IEnumerable<Device>> GetDevicesAsync();
        void UpdateDeviceAsync(Device device);
    }
}