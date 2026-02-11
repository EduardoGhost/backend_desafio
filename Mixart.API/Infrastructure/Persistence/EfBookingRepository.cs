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

    public void Add(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
    }

    public IEnumerable<Booking> GetAll()
        => _context.Bookings.ToList();

    public Booking? GetById(Guid id)
        => _context.Bookings.FirstOrDefault(b => b.Id == id);

    public void Remove(Booking booking)
    {
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
    }
}
