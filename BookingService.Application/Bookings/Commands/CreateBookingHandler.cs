using BookingService.Domain.Entidad;
using BookingService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Commands
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _repository;

        public CreateBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var isBooked = await _repository.IsVehicleBookedAsync(request.VehicleId, request.StartDate, request.EndDate);
            if (isBooked)
                throw new InvalidOperationException("El vehículo ya está reservado en ese rango de fechas.");

            var booking = new Booking(
                request.VehicleId,
                request.CustomerName,
                request.StartDate,
                request.EndDate,
                request.TotalPrice
            );

            await _repository.AddAsync(booking);
            return booking.Id;
        }
    }
}
