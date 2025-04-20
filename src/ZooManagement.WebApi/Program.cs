using ZooManagement.Application.Interfaces;
using ZooManagement.Application.Services;
using ZooManagement.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// DI registrations
builder.Services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
builder.Services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
builder.Services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();
builder.Services.AddScoped<AnimalTransferService>();
builder.Services.AddScoped<FeedingOrganizationService>();
builder.Services.AddScoped<ZooStatisticsService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZooManagement API", Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
