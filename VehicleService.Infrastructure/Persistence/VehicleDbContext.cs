using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Domain.Entidad;

namespace VehicleService.Infrastructure.Persistence
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Brand).IsRequired().HasMaxLength(100);
                entity.Property(v => v.Model).IsRequired().HasMaxLength(100);
                entity.Property(v => v.LicensePlate).IsRequired().HasMaxLength(20);
                entity.Property(v => v.Type).IsRequired();
                entity.Property(v => v.IsAvailable).IsRequired();
            });
        }
    }
}
