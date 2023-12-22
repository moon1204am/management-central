using DeviceApi.Services;
using ManagementCentral.Shared.Domain;

namespace DeviceApi.Endpoints
{
    public static class CountryEndpoints
    {
        public static void RegisterCountryUserEndpoint(this IEndpointRouteBuilder route)
        {
            var devices = route.MapGroup("");

            devices.MapGet("/countries", async (IServiceManager serviceManager) =>
            {
                return await serviceManager.CityService.GetCitiesAsync();
            });

            devices.MapGet("/country/{id}", async (int id, IServiceManager serviceManager) =>
            {
                return await serviceManager.CityService.GetCityAsync(id);
            });
        }
    }
}
