using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;
using VehicleService.Domain.Repositories;

namespace VehicleService.Application.Vehicles.Commands
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, Guid>
    {
        private readonly IVehicleRepository _repository;

        public CreateVehicleHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(request.Brand, request.Model, request.LicensePlate, request.Type);
            await _repository.AddAsync(vehicle);
            return vehicle.Id;
        }
    }
}
