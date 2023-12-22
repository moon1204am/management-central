namespace DeviceApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IDeviceRepository> _deviceRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly AppDbContext _context;
        public IDeviceRepository DeviceRepository => _deviceRepository.Value;
        public ICityRepository CityRepository => _cityRepository.Value;

        public UnitOfWork(AppDbContext context, Lazy<IDeviceRepository> deviceRepository, Lazy<ICityRepository> cityRepository)
        {
            _context = context;
            _deviceRepository = deviceRepository;
            _cityRepository = cityRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
