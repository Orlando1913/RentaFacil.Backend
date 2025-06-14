using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;

namespace VehicleService.Domain.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync(VehicleType? type, DateTime startDate, DateTime endDate);
        Task<Vehicle?> GetByIdAsync(Guid id);
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
    }
}
