using BookingService.Domain.Entidad;
using BookingService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Queries
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<Booking>>
    {
        private readonly IBookingRepository _repository;

        public GetAllBookingsHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
