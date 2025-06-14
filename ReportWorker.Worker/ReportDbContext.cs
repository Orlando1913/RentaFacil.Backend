using BookingService.Domain.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWorker.Worker
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }

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

            modelBuilder.Entity<DailyReport>(entity =>
            {
                entity.ToTable("DailyReports");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.ReportDate).IsRequired();
                entity.Property(r => r.TotalBookings).IsRequired();
                entity.Property(r => r.Notes).HasMaxLength(500);
            });
        }
    }
}
