using ManagementCentral.Shared.Domain;

namespace DeviceApi.Collections
{
    public class Devices
    {
        public static List<Device> DeviceList { get; set; } = new List<Device>();
        public Devices()
        {
            DeviceList.Add(new Device()
            {
                DeviceId = 1,
                Location = new City() { CityId = 1, Name = "Suzhou" },
                Date = new DateTime(),
                Type = "DeviceType1",
                Status = Status.Offline
            });

            DeviceList.Add(new Device()
            {
                DeviceId = 2,
                Location = new City() { CityId = 2, Name = "Hangzhou" },
                Date = new DateTime(),
                Type = "DeviceType2",
                Status = Status.Online
            });

            DeviceList.Add(new Device()
            {
                DeviceId = 3,
                Location = new City() { CityId = 3, Name = "Nanjing" },
                Date = new DateTime(),
                Type = "DeviceType3",
                Status = Status.Online
            });

            DeviceList.Add(new Device()
            {
                DeviceId = 4,
                Location = new City() { CityId = 4, Name = "Seoul" },
                Date = new DateTime(),
                Type = "DeviceType4",
                Status = Status.Offline
            });
        }
        
    }
}
