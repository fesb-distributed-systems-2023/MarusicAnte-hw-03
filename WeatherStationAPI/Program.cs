using WeatherStationAPI.Configuration;
using WeatherStationAPI.Logic;
using WeatherStationAPI.Repositories;
using WeatherStationAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ValidationConfiguration>(builder.Configuration.GetSection("Validation"));
builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("Database"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<WeatherStationRepository>();
builder.Services.AddSingleton<IWeatherStationLogic, WeatherStationLogic>();
builder.Services.AddSingleton<IWeatherStationRepository, WeatherStationRepository_SQL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
