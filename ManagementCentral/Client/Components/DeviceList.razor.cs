using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace ManagementCentral.Client.Components
{
    //[Authorize]
    public partial class DeviceList
    {
        [Parameter]
        public List<Device> Devices { get; set; } = new List<Device>();

        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;

        //[Inject]
        //public IDeviceDataService? DeviceDataService { get; set; }

        //protected async override Task OnInitializedAsync()
        //{
        //    base.OnInitialized();
        //    Devices = (await DeviceDataService!.GetDevices())?.ToList()!;
        //    Console.ReadLine();
        //}
    }
}
