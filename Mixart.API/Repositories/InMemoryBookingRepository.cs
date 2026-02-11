using Mixart.API.Domain.Entities;

namespace Mixart.API.Repositories;

public class InMemoryBookingRepository : IBookingRepository
{
    private static readonly List<Booking> _bookings = [];

    public void Add(Booking booking)
        => _bookings.Add(booking);

    public IEnumerable<Booking> GetAll()
        => _bookings;

    public Booking? GetById(Guid id)
        => _bookings.FirstOrDefault(b => b.Id == id);

    public void Remove(Booking booking)
        => _bookings.Remove(booking);
}
