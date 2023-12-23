using ManagementCentral.Shared.Domain;
using System.Text.Json;

namespace ManagementCentral.Client.Services
{
    public class CityDataService : ICityDataService
    {
        private readonly HttpClient _httpClient;

        public CityDataService(/*HttpClient httpClient*/ IHttpClientFactory httpClientFactory)
        {
            //_httpClient = httpClient;
            _httpClient = httpClientFactory.CreateClient("CitiesClient");
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<City>>(await _httpClient.GetStreamAsync("/countries"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<City> GetCityAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<City>(await _httpClient.GetStreamAsync($"/countries/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
