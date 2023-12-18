using ManagementCentral.Client.Pages;
using ManagementCentral.Shared.Domain;

namespace ManagementCentral.Client.Services
{
    public class DeviceServiceData : IDeviceDataService
    {
        public static List<Device> DeviceList { get; set; } = new List<Device>();

        public DeviceServiceData()
        {

            DeviceList.Add(new Device()
            {
                DeviceId = 1,
                Location = Location.Hangzhou,
                Date = new DateTime(),
                Type = "DeviceType1",
                Status = Status.Offline
            });

            DeviceList.Add(new Device()
            {
                DeviceId = 2,
                Location = Location.Wuhan,
                Date = new DateTime(),
                Type = "DeviceType2",
                Status = Status.Online
            });

            DeviceList.Add(new Device()
            {
                DeviceId = 3,
                Location = Location.Suzhou,
                Date = new DateTime(),
                Type = "DeviceType3",
                Status = Status.Online
            });

            DeviceList.Add(new Device()
            {
                DeviceId = 4,
                Location = Location.Shanghai,
                Date = new DateTime(),
                Type = "DeviceType4",
                Status = Status.Offline
            });
        }
        public void AddDevice(Device device)
        {
            Random rnd = new Random();
            device.DeviceId = rnd.Next(100000);
            DeviceList.Add(device);
        }

        public void DeleteDevice(int id)
        {
            var deviceToDelete = DeviceList.FirstOrDefault(d => d.DeviceId == id);
            if(deviceToDelete != null) 
            { 
                DeviceList.Remove(deviceToDelete);
            }
        }

        public Device? GetDevice(int id)
        {
            return DeviceList.FirstOrDefault(d => d.DeviceId == id);
        }

        public List<Device> GetDevices()
        {
            return DeviceList;
        }

        public void UpdateDevice(Device updatedDevice)
        {
            var device = DeviceList.FirstOrDefault(d => d.DeviceId == updatedDevice.DeviceId);
            if(device != null)
            {
                device.Location = updatedDevice.Location;
                device.Date = updatedDevice.Date;
                device.Type = updatedDevice.Type;
                device.Status = updatedDevice.Status;
            }
        }
    }
}
