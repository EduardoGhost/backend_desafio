using Mixart.API.Domain.Entities;

namespace Mixart.API.Repositories;

public class InMemoryBookingRepository : IBookingRepository
{
    private static readonly List<Booking> _bookings = new();

    public Task AddAsync(Booking booking)
    {
        _bookings.Add(booking);
        return Task.CompletedTask;
    }

    public Task<List<Booking>> GetAllAsync()
{
    return Task.FromResult(_bookings.ToList());
}

    public Task<Booking?> GetByIdAsync(Guid id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(booking);
    }

    public Task RemoveAsync(Booking booking)
    {
        _bookings.Remove(booking);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Booking booking)
    {
        var index = _bookings.FindIndex(b => b.Id == booking.Id);
        if (index >= 0)
            _bookings[index] = booking;

        return Task.CompletedTask;
    }
}