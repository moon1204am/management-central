using DeviceApi;
using DeviceApi.Endpoints;
using DeviceApi.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

//builder.Services.AddDbContext<DeviceDbContext>(options =>
//              options.UseSqlServer(builder.Configuration.GetConnectionString("DeviceDbContext")
//              ?? throw new InvalidOperationException("Connection string 'DeviceDbContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

//app.MapGet("/device", () => "Getting a device from API");

//app.MapGet("/device/{deviceId}/button/{buttonId}", (int deviceId, int buttonId) => $"Device id {deviceId} and Button id {buttonId}");

//app.MapGet("/device/{deviceId}", (int deviceId) =>
//{

//});

app.RegisterDeviceUserEndpoint();
app.RegisterCountryUserEndpoint();

app.UseCors(ApiConstants.policyName);

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
