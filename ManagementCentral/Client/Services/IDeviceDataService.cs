using ManagementCentral.Shared.Domain;

namespace ManagementCentral.Client.Services
{
    public interface IDeviceDataService
    {
        Task<IEnumerable<Device>?> GetDevices();

        Task<Device?> GetDevice(int id);

        Task DeleteDevice(int id);

        Task UpdateDevice(Device updatedDevice);

        Task<Device?> AddDevice(Device device);
    }
}
