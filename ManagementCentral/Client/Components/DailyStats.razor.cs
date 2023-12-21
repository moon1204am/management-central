using ManagementCentral.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Components
{
    public partial class DailyStats
    {
        [Inject]
        public IDeviceDataService DeviceDataService { get; set; }
        public int NumberOfDevices { get; set; }

        protected async override Task OnInitializedAsync()
        {
            NumberOfDevices = (await DeviceDataService.GetDevices()).Count();
            base.OnInitialized();
        }
    }
}
