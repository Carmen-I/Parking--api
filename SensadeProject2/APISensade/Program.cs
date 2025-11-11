using API.BusinessLogic;
using SensadeData.DatabaseLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IParkingArea, ParkingAreaDB>();
builder.Services.AddScoped<IParkingAreaLogic, ParkingAreaLogic>();

builder.Services.AddScoped<IParkingSpace, ParkingSpaceDB>();
builder.Services.AddScoped<IParkingSpaceLogic, ParkingSpaceLogic>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
