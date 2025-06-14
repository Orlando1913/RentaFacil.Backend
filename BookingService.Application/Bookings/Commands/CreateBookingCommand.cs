using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Commands
{
    public record CreateBookingCommand(
         Guid VehicleId,
         string CustomerName,
         DateTime StartDate,
         DateTime EndDate,
         decimal TotalPrice
     ) : IRequest<Guid>;
}
