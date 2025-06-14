using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookingService.Infrastructure.Persistence
{
    public class BookingDbContextFactory : IDesignTimeDbContextFactory<BookingDbContext>
    {
        public BookingDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../ReportWorker.Worker");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("BookingDb");

            var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BookingDbContext(optionsBuilder.Options);
        }
    }
}
