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
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, Booking?>
    {
        private readonly IBookingRepository _repository;

        public GetBookingByIdHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Booking?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
