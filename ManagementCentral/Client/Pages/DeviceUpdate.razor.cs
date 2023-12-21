using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class DeviceUpdate
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string DeviceId { get; set; }
        public Device Device { get; set; } = new Device();

        protected async override Task OnInitializedAsync()
        {
            Device = await DeviceDataService.GetDevice(int.Parse(DeviceId));
            base.OnInitialized();
        }

        protected async Task HandleValidSubmit()
        {
            await DeviceDataService.UpdateDevice(Device);
            NavigationManager.NavigateTo($"/dashboard");
        }
    }
}
