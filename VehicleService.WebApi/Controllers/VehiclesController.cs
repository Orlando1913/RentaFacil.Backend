using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleService.Application.Vehicles.Commands;
using VehicleService.Application.Vehicles.Queries;
using VehicleService.Domain.Entidad;

namespace VehicleService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAvailableVehicles), new { id }, new { id });
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableVehicles(
             [FromQuery] VehicleType? type,
             [FromQuery] DateTime startDate,
             [FromQuery] DateTime endDate)
        {
            var query = new GetAvailableVehiclesQuery
            {
                Type = type,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
