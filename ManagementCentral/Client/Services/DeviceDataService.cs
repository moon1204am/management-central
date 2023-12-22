using ManagementCentral.Client.Pages;
using ManagementCentral.Shared.Domain;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace ManagementCentral.Client.Services
{
    public class DeviceDataService : IDeviceDataService
    {
        private readonly HttpClient _httpClient;

        //public static List<Device> DeviceList { get; set; } = new List<Device>();

        public DeviceDataService(HttpClient httpClient)
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
            var devicesResponse = await _httpClient.GetStreamAsync($"/devices");
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Device>>(devicesResponse, new JsonSerializerOptions() { /*PropertyNameCaseInsensitive = true*/ PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return list;

            //var request = new HttpRequestMessage(HttpMethod.Get, "/devices");
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            //response.EnsureSuccessStatusCode();

            //var stream = await response.Content.ReadAsStreamAsync();
            //var result = JsonSerializer.Deserialize<IEnumerable<Device>>(stream, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            //return result;
        }

        public async Task UpdateDevice(Device updatedDevice)
        {
            var deviceJson = new StringContent(JsonSerializer.Serialize(updatedDevice), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("/deviceupdate", deviceJson);
        }
    }
}
