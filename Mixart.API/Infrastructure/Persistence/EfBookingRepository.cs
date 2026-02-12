using Microsoft.EntityFrameworkCore;
using Mixart.API.Domain.Entities;
using Mixart.API.Repositories;

namespace Mixart.API.Infrastructure.Persistence;

public class EfBookingRepository : IBookingRepository
{
    private readonly MixartDbContext _context;

    public EfBookingRepository(MixartDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Booking>> GetAllAsync()
        => await _context.Bookings.ToListAsync();

    public async Task<Booking?> GetByIdAsync(Guid id)
        => await _context.Bookings
            .FirstOrDefaultAsync(b => b.Id == id);

    public async Task RemoveAsync(Booking booking)
    {
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
}