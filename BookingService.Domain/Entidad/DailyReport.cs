using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Entidad
{
    public class DailyReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime ReportDate { get; set; }
        public int TotalBookings { get; set; }
        public string Details { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
