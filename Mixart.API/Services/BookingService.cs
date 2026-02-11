using Mixart.API.Domain.Entities;
using Mixart.API.Domain.Enums;
using Mixart.API.Repositories;

namespace Mixart.API.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;

    public BookingService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public Booking Create(
        int artistId,
        int contractorId,
        DateOnly date,
        TimeOnly startTime,
        decimal totalValue
    )
    {
        var booking = new Booking
        {
            ArtistId = artistId,
            ContractorId = contractorId,
            Date = date,
            StartTime = startTime,
            TotalValue = totalValue,
            Status = BookingStatus.Pending
        };

        _repository.Add(booking);
        return booking;
    }

    public IEnumerable<Booking> GetAll()
        => _repository.GetAll();

    public Booking GetById(Guid id)
        => _repository.GetById(id)
           ?? throw new InvalidOperationException("Reserva não encontrada.");

    public Booking Accept(Guid id)
    {
        var booking = GetById(id);

        if (booking.Status != BookingStatus.Pending)
            throw new InvalidOperationException("Reserva não está pendente.");

        booking.Status = BookingStatus.Accepted;
        return booking;
    }

    public Booking Reject(Guid id)
    {
        var booking = GetById(id);

        if (booking.Status != BookingStatus.Pending)
            throw new InvalidOperationException("Reserva não está pendente.");

        booking.Status = BookingStatus.Rejected;
        return booking;
    }

    public void Delete(Guid id)
    {
        var booking = GetById(id);

        if (booking.Status == BookingStatus.Accepted)
            throw new InvalidOperationException("Reservas aceitas não podem ser removidas.");

        _repository.Remove(booking);
    }
}
