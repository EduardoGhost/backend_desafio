using Mixart.API.Domain.Entities;

namespace Mixart.API.Repositories;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);

    Task<List<Booking>> GetAllAsync();

    Task<Booking?> GetByIdAsync(Guid id);

    Task RemoveAsync(Booking booking);

    Task UpdateAsync(Booking booking);
}