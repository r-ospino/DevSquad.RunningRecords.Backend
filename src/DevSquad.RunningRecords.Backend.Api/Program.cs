using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using DevSquad.RunningRecords.Backend.Domain;
using DevSquad.RunningRecords.Backend.Infrastructure;
using DevSquad.RunningRecords.Backend.Infrastructure.Context;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RecordARunCommand>());

builder.Services.AddScoped<IRunningRecordRepository, RunningRecordsRepository>();
builder.Services.AddDbContext<RunningContext>(opt => opt.UseSqlite(""));

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();
