using DeviceApi.Collections;
using ManagementCentral.Shared.Domain;

namespace DeviceApi.Endpoints
{
    public static class DeviceEndpoints
    {
        public static void RegisterUserEndpoint(this IEndpointRouteBuilder route)
        {
            var devices = route.MapGroup("");

            devices.MapGet("/devices", () => 
                { 
                    return Devices.DeviceList; 
                });

            devices.MapGet("/device/{id}", (int id) =>
            {
                return Devices.DeviceList.FirstOrDefault(d => d.DeviceId == id);
            });

            devices.MapPost("/deviceadd", (Device device) =>
            {
                Random rnd = new Random();
                device.DeviceId = rnd.Next(100000);
                Devices.DeviceList.Add(device);
            });

            devices.MapDelete("/devicedelete", (int id) =>
            {
                var deviceToDelete = Devices.DeviceList.FirstOrDefault(d => d.DeviceId == id);
                if (deviceToDelete != null)
                {
                    Devices.DeviceList.Remove(deviceToDelete);
                }
            });

            devices.MapPut("/deviceupdate", (Device device) =>
            {
                var deviceToUpdate = Devices.DeviceList.FirstOrDefault(d => d.DeviceId == device.DeviceId);
                if (device != null)
                {
                    deviceToUpdate.Location = device.Location;
                    deviceToUpdate.Date = device.Date;
                    deviceToUpdate.Type = device.Type;
                    deviceToUpdate.Status = device.Status;
                }
            });
        }
    }
}
