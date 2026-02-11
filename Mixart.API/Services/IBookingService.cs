using Mixart.API.Domain.Entities;

namespace Mixart.API.Services;

public interface IBookingService
{
    Booking Create(
        int artistId,
        int contractorId,
        DateOnly date,
        TimeOnly startTime,
        decimal totalValue
    );

    IEnumerable<Booking> GetAll();
    Booking GetById(Guid id);
    Booking Accept(Guid id);
    Booking Reject(Guid id);
    void Delete(Guid id);
}
