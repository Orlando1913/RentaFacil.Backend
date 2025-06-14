using BookingService.Domain.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Booking>> GetBookingsByVehicleIdAsync(Guid vehicleId);
        Task<bool> IsVehicleBookedAsync(Guid vehicleId, DateTime startDate, DateTime endDate);
    }
}
