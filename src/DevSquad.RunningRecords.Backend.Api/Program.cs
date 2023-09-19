using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using DevSquad.RunningRecords.Backend.Domain;
using DevSquad.RunningRecords.Backend.Infrastructure;
using DevSquad.RunningRecords.Backend.Infrastructure.Context;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RecordARunCommand>());

builder.Services.AddScoped<IRunningRecordRepository, RunningRecordsRepository>();
builder.Services.AddDbContext<RunningContext>(opt => opt.UseSqlite("MyDatabase"));

builder.Services.AddHealthChecks()
    .AddDbContextCheck<RunningContext>();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseAuthorization();
app.MapHealthChecks("/health/startup");
app.MapHealthChecks("/health/live");
app.MapHealthChecks("/health/ready");
app.UseFastEndpoints();

app.Run();
