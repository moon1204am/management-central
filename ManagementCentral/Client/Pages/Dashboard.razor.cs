using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class Dashboard
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        public List<Device> Devices { get; set; } = new List<Device>();
        public int NumberOfDevices { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Devices = (await DeviceDataService!.GetDevices())?.ToList()!;
            NumberOfDevices = Devices.Count;
            //Console.ReadLine();
        }
    }
}
