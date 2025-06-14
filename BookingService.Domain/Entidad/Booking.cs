using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Entidad
{
    public class Booking
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid VehicleId { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public decimal TotalPrice { get; private set; }

        public Booking(Guid vehicleId, string customerName, DateTime startDate, DateTime endDate, decimal totalPrice)
        {
            if (endDate <= startDate)
                throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio.");

            VehicleId = vehicleId;
            CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
            StartDate = startDate;
            EndDate = endDate;
            TotalPrice = totalPrice;
        }

        public bool Overlaps(DateTime startDate, DateTime endDate)
        {
            return StartDate < endDate && startDate < EndDate;
        }
    }
}
