using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;
using VehicleService.Domain.Repositories;

namespace VehicleService.Application.Vehicles.Queries
{
    public class GetAvailableVehiclesHandler : IRequestHandler<GetAvailableVehiclesQuery, IEnumerable<Vehicle>>
    {
        private readonly IVehicleRepository _repository;

        public GetAvailableVehiclesHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Vehicle>> Handle(GetAvailableVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAvailableVehiclesAsync(request.Type, request.StartDate, request.EndDate);
        }
    }
}
