using BookingService.Domain.Entidad;
using BookingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ReportWorker.Worker
{
    public class ReportBackgroundService : BackgroundService
    {
        private readonly ILogger<ReportBackgroundService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ReportBackgroundService(ILogger<ReportBackgroundService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var sourceDb = scope.ServiceProvider.GetRequiredService<SourceBookingDbContext>();
                    var reportDb = scope.ServiceProvider.GetRequiredService<ReportDbContext>();

                    var fecha = DateTime.Today.AddDays(-1);

                    bool yaExiste = await reportDb.DailyReports
                        .AnyAsync(r => r.ReportDate == fecha, stoppingToken);

                    if (!yaExiste)
                    {
                        var reservas = await sourceDb.Bookings
                            .Where(b => b.StartDate.Date == fecha)
                            .ToListAsync(stoppingToken);

                        var reporte = new DailyReport
                        {
                            ReportDate = fecha,
                            TotalBookings = reservas.Count,
                            Notes = $"Se registraron {reservas.Count} reservas el {fecha:yyyy-MM-dd}"
                        };

                        reportDb.DailyReports.Add(reporte);
                        await reportDb.SaveChangesAsync(stoppingToken);

                        _logger.LogInformation("📊 Reporte generado: {Fecha} - {Total} reservas.",
                            fecha.ToShortDateString(), reservas.Count);
                    }
                    else
                    {
                        _logger.LogInformation("ℹ️ Ya existe un reporte para el día {Fecha}.", fecha.ToShortDateString());
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Error al generar el reporte diario.");
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // o TimeSpan.FromDays(1) en producción
            }
        }
    }
}
