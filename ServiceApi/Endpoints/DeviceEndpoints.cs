using DeviceApi.Collections;
using DeviceApi.Services;
using ManagementCentral.Shared.Domain;

namespace DeviceApi.Endpoints
{
    public static class DeviceEndpoints
    {
        public static void RegisterDeviceUserEndpoint(this IEndpointRouteBuilder route)
        {
            var devices = route.MapGroup("");

            devices.MapGet("/devices", async (IServiceManager serviceManager) => 
                {
                    return await serviceManager.DeviceService.GetDevicesAsync();
                    //return Devices.DeviceList; 
                });

            devices.MapGet("/device/{id}", async (int id, IServiceManager serviceManager) =>
            {
                return await serviceManager.DeviceService.GetDeviceAsync(id);
                //return Devices.DeviceList.FirstOrDefault(d => d.DeviceId == id);
            });

            devices.MapPost("/deviceadd", async (Device device, IServiceManager serviceManager) =>
            {
                await serviceManager.DeviceService.AddDeviceAsync(device);
                //Random rnd = new Random();
                //device.DeviceId = rnd.Next(100000);
                //Devices.DeviceList.Add(device);
            });

            devices.MapDelete("/devicedelete", (int id, IServiceManager serviceManager) =>
            {
                serviceManager.DeviceService.DeleteDeviceAsync(id);
                //var deviceToDelete = Devices.DeviceList.FirstOrDefault(d => d.DeviceId == id);
                //if (deviceToDelete != null)
                //{
                //    Devices.DeviceList.Remove(deviceToDelete);
                //}
            });

            devices.MapPut("/deviceupdate", (Device device, IServiceManager serviceManager) =>
            {
                serviceManager.DeviceService.UpdateDeviceAsync(device);
                //var deviceToUpdate = Devices.DeviceList.FirstOrDefault(d => d.DeviceId == deviceId);
                //if (device != null)
                //{
                //    deviceToUpdate.Location = device.Location;
                //    deviceToUpdate.Date = device.Date;
                //    deviceToUpdate.Type = device.Type;
                //    deviceToUpdate.Status = device.Status;
                //}
            });
        }
    }
}
