using Mixart.API.Domain.Entities;

namespace Mixart.API.Services;

public interface IBookingService
{
    Task<Booking> CreateAsync(
        int artistId,
        int contractorId,
        DateOnly date,
        TimeOnly startTime,
        decimal totalValue
    );

    Task<List<Booking>> GetAll();

    Task<Booking> GetById(Guid id);

    Task<Booking> Accept(Guid id);

    Task<Booking> Reject(Guid id);

    Task Delete(Guid id);
}
