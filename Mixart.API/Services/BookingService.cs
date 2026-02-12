using Mixart.API.Domain.Entities;
using Mixart.API.Domain.Enums;
using Mixart.API.Repositories;

namespace Mixart.API.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly ITransactionRepository _transactionRepository;

    public BookingService(
    IBookingRepository bookingRepository,
    IWalletRepository walletRepository,
    ITransactionRepository transactionRepository)
{
    _bookingRepository = bookingRepository;
    _walletRepository = walletRepository;
    _transactionRepository = transactionRepository;
}

    public async Task<Booking> CreateAsync(
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

        await _bookingRepository.AddAsync(booking);
        return booking;
    }

   public async Task<List<Booking>> GetAll()
        => await _bookingRepository.GetAllAsync();

    public async Task<Booking> GetById(Guid id)
        => await _bookingRepository.GetByIdAsync(id)
           ?? throw new InvalidOperationException("Reserva não encontrada.");

    public async Task<Booking> Accept(Guid id)
{
    var booking = await _bookingRepository.GetByIdAsync(id)
        ?? throw new InvalidOperationException("Reserva não encontrada.");

    if (booking.Status != BookingStatus.Pending)
        throw new InvalidOperationException("Reserva não está pendente.");

    var signalAmount = booking.TotalValue * 0.30m;

    var wallet = await _walletRepository.GetByArtistIdAsync(booking.ArtistId)
        ?? throw new InvalidOperationException("Carteira não encontrada.");

    wallet.Balance += signalAmount;

    await _walletRepository.UpdateAsync(wallet);

    var transaction = new Transaction
    {
        Id = Guid.NewGuid(),
        WalletId = wallet.Id,
        BookingId = booking.Id,
        Amount = signalAmount,
        Type = TransactionType.Credit,
        Description = $"Sinal de 30% da reserva {booking.Id}",
        CreatedAt = DateTime.UtcNow
    };

    booking.Status = BookingStatus.Accepted;

    await _bookingRepository.UpdateAsync(booking);
    await _transactionRepository.AddAsync(transaction);

    return booking;
}

    public async Task<Booking> Reject(Guid id)
    {
        var booking = await GetById(id);

        if (booking.Status != BookingStatus.Pending)
            throw new InvalidOperationException("Reserva não está pendente.");

        booking.Status = BookingStatus.Rejected;

        await _bookingRepository.UpdateAsync(booking);

        return booking;
    }

    public async Task Delete(Guid id)
    {
        var booking = await GetById(id);

        if (booking.Status == BookingStatus.Accepted)
            throw new InvalidOperationException("Reservas aceitas não podem ser removidas.");

        await _bookingRepository.RemoveAsync(booking);
    }
}
