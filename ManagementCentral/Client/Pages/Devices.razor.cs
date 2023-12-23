using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class Devices
    {
        [Parameter]
        public List<Device> DeviceList { get; set; } = new List<Device>();
    }
}
