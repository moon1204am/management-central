using ManagementCentral.Shared.Domain;

namespace DeviceApi.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAsync();
        Task<City?> GetAsync(int id);
    }
}