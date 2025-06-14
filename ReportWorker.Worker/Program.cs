using Microsoft.EntityFrameworkCore;
using ReportWorker.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<SourceBookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SourceBookingDb")));

builder.Services.AddDbContext<ReportDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReportDb")));

builder.Services.AddHostedService<ReportBackgroundService>();

var host = builder.Build();
host.Run();
