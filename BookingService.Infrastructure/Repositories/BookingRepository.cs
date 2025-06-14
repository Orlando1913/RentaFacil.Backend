using BookingService.Domain.Entidad;
using BookingService.Domain.Repositories;
using BookingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;

        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetBookingsByVehicleIdAsync(Guid vehicleId)
        {
            return await _context.Bookings
                .Where(b => b.VehicleId == vehicleId)
                .ToListAsync();
        }

        public async Task<bool> IsVehicleBookedAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings.AnyAsync(b =>
                b.VehicleId == vehicleId &&
                ((startDate >= b.StartDate && startDate < b.EndDate) ||
                 (endDate > b.StartDate && endDate <= b.EndDate) ||
                 (startDate <= b.StartDate && endDate >= b.EndDate)));
        }
    }
}
