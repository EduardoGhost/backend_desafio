using Microsoft.EntityFrameworkCore;
using Mixart.API.Domain.Entities;

namespace Mixart.API.Infrastructure.Persistence;

public class MixartDbContext : DbContext
{
    public MixartDbContext(DbContextOptions<MixartDbContext> options)
        : base(options)
    {
    }

    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
}
