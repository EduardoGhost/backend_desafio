using Mixart.API.Domain.Entities;

namespace Mixart.API.Repositories;

public interface IBookingRepository
{
    void Add(Booking booking);
    IEnumerable<Booking> GetAll();
    Booking? GetById(Guid id);
    void Remove(Booking booking);
}
