using BookingService.Domain.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWorker.Worker
{
    public class SourceBookingDbContext : DbContext
    {
        public SourceBookingDbContext(DbContextOptions<SourceBookingDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Bookings");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.VehicleId).IsRequired();
                entity.Property(b => b.CustomerName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.StartDate).IsRequired();
                entity.Property(b => b.EndDate).IsRequired();
                entity.Property(b => b.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            });
        }
    }
}
