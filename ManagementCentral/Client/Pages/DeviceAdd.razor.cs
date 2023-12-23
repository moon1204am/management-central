using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class DeviceAdd
    {
        [Inject]
        public IDeviceDataService DeviceDataService { get; set; }
        [Inject]
        public ICityDataService CityDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Device Device { get; set; } = new Device();
        [Parameter]
        public string? DeviceId { get; set; }
        public List<City> Cities { get; set; } = new List<City>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Cities = (await CityDataService.GetCitiesAsync()).ToList();

            int.TryParse(DeviceId, out var deviceId);
            if (deviceId != 0)
                Device = await DeviceDataService.GetDevice(int.Parse(DeviceId));
        }

        protected async Task HandleValidSubmit()
        {
            if(Device.DeviceId == 0)
            {
                Device = await DeviceDataService.AddDevice(Device);
            }
            else
            {
                await DeviceDataService.UpdateDevice(Device);
            }
            
            NavigationManager.NavigateTo($"/dashboard");
        }
    }
}
