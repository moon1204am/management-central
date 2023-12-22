using ManagementCentral.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeviceApi.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<City>> GetAsync()
        {
            return await _context.City!.ToListAsync();
        }

        public async Task<City?> GetAsync(int id)
        {
            return await _context.City!.FirstOrDefaultAsync(c => c.CityId == id);
        }
    }
}
