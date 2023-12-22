
using DeviceApi.Services;

namespace DeviceApi.Repositories
{
    public interface IUnitOfWork
    {
        IDeviceRepository DeviceRepository { get; }
        ICityRepository CityRepository { get; }
        Task SaveChangesAsync();
    }
}