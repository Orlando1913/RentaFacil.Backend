using BookingService.Domain.Entidad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Queries
{
    public record GetAllBookingsQuery : IRequest<IEnumerable<Booking>>;
}
