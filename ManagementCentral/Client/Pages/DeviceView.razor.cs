using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class DeviceView
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        [Parameter]
        public string DeviceId { get; set; }
        public Device Device { get; set; } = new Device();

        protected async override Task OnInitializedAsync()
        {
            Device = await DeviceDataService.GetDevice(int.Parse(DeviceId));
        }

        

    }
}
