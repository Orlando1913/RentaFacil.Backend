using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;

namespace VehicleService.Application.Vehicles.Queries
{
    public class GetAvailableVehiclesQuery : IRequest<IEnumerable<Vehicle>>
    {
        public VehicleType? Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
