using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;

namespace VehicleService.Application.Vehicles.Commands
{
    public class CreateVehicleCommand : IRequest<Guid>
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
        public VehicleType? Type { get; set; }
    }
}
