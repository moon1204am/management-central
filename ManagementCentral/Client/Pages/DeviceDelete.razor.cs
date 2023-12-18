﻿using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class DeviceDelete
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string DeviceId { get; set; }
        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));
            //base.OnInitialized();
        }

        protected void Delete(string deviceId)
        {
            DeviceDataService.DeleteDevice(int.Parse(deviceId));
            NavigationManager.NavigateTo($"/dashboard");
        }
    }
}
