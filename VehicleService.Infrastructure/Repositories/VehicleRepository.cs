using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;
using VehicleService.Domain.Repositories;
using VehicleService.Infrastructure.Persistence;

namespace VehicleService.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync(VehicleType? type, DateTime startDate, DateTime endDate)
        {
            var query = _context.Vehicles.AsQueryable();

            query = query.Where(v => v.IsAvailable);

            if (type.HasValue)
                query = query.Where(v => v.Type == type.Value);

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}
