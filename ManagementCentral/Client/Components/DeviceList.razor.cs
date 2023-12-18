using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Components
{
    public partial class DeviceList
    {
        public List<Device> Devices { get; set; } = new List<Device>();

        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Devices = DeviceServiceData.DeviceList;
        }
    }
}
