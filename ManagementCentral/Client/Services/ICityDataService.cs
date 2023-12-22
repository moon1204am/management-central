using ManagementCentral.Shared.Domain;

namespace ManagementCentral.Client.Services
{
    public interface ICityDataService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityAsync(int id);
    }
}