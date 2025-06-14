using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Commands
{
    public record DeleteBookingCommand(Guid Id) : IRequest<bool>;
}
