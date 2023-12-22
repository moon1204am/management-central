using DeviceApi.Repositories;
using ManagementCentral.Shared.Domain;

namespace DeviceApi.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _unitOfWork.CityRepository.GetAsync();
        }
        public async Task<City?> GetCityAsync(int cityId)
        {
            return await _unitOfWork.CityRepository.GetAsync(cityId);
        }
    }
}
