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

builder.Services.AddScoped<IWalletRepository, EfWalletRepository>();
builder.Services.AddScoped<IWalletService, WalletService>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, EfTransactionRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutter",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFlutter");
app.UseAuthorization();
app.MapControllers();
app.Run();
