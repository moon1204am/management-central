using DeviceApi.Repositories;
using ManagementCentral.Shared.Domain;

namespace DeviceApi.Services
{
    // mapping should be in this class.
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            return await _unitOfWork.DeviceRepository.GetAsync();
        }
        public async Task<Device?> GetDeviceAsync(int deviceId)
        {
            return await _unitOfWork.DeviceRepository.GetAsync(deviceId);
        }
        public async Task AddDeviceAsync(Device device)
        {
            await _unitOfWork.DeviceRepository.AddAsync(device);
            await _unitOfWork.SaveChangesAsync();
        }
        public async void UpdateDeviceAsync(Device device)
        {
            _unitOfWork.DeviceRepository.Update(device);
            await _unitOfWork.SaveChangesAsync();
        }
        public async void DeleteDeviceAsync(int deviceId)
        {
            var deviceToDelete = await _unitOfWork.DeviceRepository.GetAsync(deviceId);
            if (deviceToDelete != null) _unitOfWork.DeviceRepository.Delete(deviceToDelete);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
