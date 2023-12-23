using ManagementCentral.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeviceApi.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Device>> GetAsync()
        {
            return await _context.Device!.Include(d => d.City).ToListAsync();
        }

        public async Task<Device?> GetAsync(int id)
        {
            return await _context.Device!.Include(d => d.City).FirstOrDefaultAsync(d => d.DeviceId == id);
        }

        public async Task AddAsync(Device device)
        {
            await _context.Device!.AddAsync(device);
        }

        public void Update(Device device)
        {
            _context.Device!.Update(device);
        }

        public void Delete(Device device)
        {
            _context.Device!.Remove(device);
        }
    }
}
