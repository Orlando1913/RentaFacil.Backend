using BookingService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Commands
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IBookingRepository _repository;

        public DeleteBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetByIdAsync(request.Id);
            if (booking == null) return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
