using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleService.Domain.Entidad
{

    public enum VehicleType
    {
        Sedan,
        SUV,
        Hatchback,
        Pickup,
        Van
    }

    public class Vehicle
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }
        public VehicleType? Type { get; private set; }
        public bool IsAvailable { get; private set; } = true;

        public Vehicle(string brand, string model, string licensePlate, VehicleType type)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Type = type;
        }

        public Vehicle(string brand, string model, string licensePlate, VehicleType? type)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Type = type;
        }

        public void MarkAsUnavailable()
        {
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }
    }
}
