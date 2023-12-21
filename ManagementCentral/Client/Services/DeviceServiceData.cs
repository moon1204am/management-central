using ManagementCentral.Client.Pages;
using ManagementCentral.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace ManagementCentral.Client.Services
{
    public class DeviceServiceData : IDeviceDataService
    {
        private readonly HttpClient _httpClient;

        //public static List<Device> DeviceList { get; set; } = new List<Device>();

        public DeviceServiceData(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Device?> AddDevice(Device device)
        {
            // serialize device object to json
            var deviceJson = new StringContent(JsonSerializer.Serialize(device), Encoding.UTF8, "application/json");
            // call api with json
            var response = await _httpClient.PostAsync("/deviceadd", deviceJson);
            // if success, deserialize the created device object and return it
            if(response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Device>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task DeleteDevice(int id)
        {
            //var deviceToDelete = GetDevice(id);
            //if(deviceToDelete != null)
            //{
            //    await _httpClient.DeleteAsync($"/devicedelete/{id}");
            //}

            await _httpClient.DeleteAsync($"/devicedelete/{id}");
        }

        public async Task<Device?> GetDevice(int id)
        {
            var deviceResponse = await _httpClient.GetStreamAsync($"/device/{id}");

            return await JsonSerializer.DeserializeAsync<Device>(deviceResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Device>?> GetDevices()
        {
            //var devicesResponse = await _httpClient.GetStreamAsync($"/devices");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Device>>(await _httpClient.GetStreamAsync($"/devices"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //return list;
        }

        public async Task UpdateDevice(Device updatedDevice)
        {
            var deviceJson = new StringContent(JsonSerializer.Serialize(updatedDevice), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("/deviceupdate", deviceJson);
        }
    }
}
