using BookingService.Application.Bookings.Commands;
using BookingService.Application.Bookings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            var bookingId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookingById), new { id = bookingId }, new { Id = bookingId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var booking = await _mediator.Send(new GetBookingByIdQuery(id));
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            var success = await _mediator.Send(new DeleteBookingCommand(id));
            return success ? NoContent() : NotFound();
        }
    }
}
