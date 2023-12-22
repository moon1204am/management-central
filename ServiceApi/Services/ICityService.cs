using ManagementCentral.Shared.Domain;

namespace DeviceApi.Services
{
    public interface ICityService
    {
        Task<City?> GetCityAsync(int cityId);
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}