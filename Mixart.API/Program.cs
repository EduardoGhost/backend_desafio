using Microsoft.EntityFrameworkCore;
using Mixart.API.Infrastructure.Persistence;
using Mixart.API.Services;
using Mixart.API.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MixartDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=mixart2;Username=teste;Password=1234"));


builder.Services.AddScoped<IBookingRepository, EfBookingRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookingService, BookingService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
