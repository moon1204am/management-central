using ManagementCentral.Shared.Domain;

namespace DeviceApi.Repositories
{
    public interface IDeviceRepository
    {
        Task AddAsync(Device device);
        void Delete(Device device);
        Task<IEnumerable<Device>> GetAsync();
        Task<Device?> GetAsync(int id);
        void Update(Device device);
    }
}