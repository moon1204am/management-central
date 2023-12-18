using ManagementCentral.Shared.Domain;

namespace ManagementCentral.Client.Services
{
    public interface IDeviceDataService
    {
        List<Device> GetDevices();

        Device? GetDevice(int Id);

        void DeleteDevice(int id);

        void UpdateDevice(Device device);

        void AddDevice(Device device);
    }
}
