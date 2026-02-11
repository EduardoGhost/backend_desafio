using Mixart.API.Domain.Entities;

namespace Mixart.API.Controllers.Responses;

public static class BookingMapper
{
    public static BookingResponse ToResponse(this Booking booking)
    {
        return new BookingResponse
        {
            Id = booking.Id,
            ArtistId = booking.ArtistId,
            ContractorId = booking.ContractorId,
            Date = booking.Date,
            StartTime = booking.StartTime,
            TotalValue = booking.TotalValue,
            Status = booking.Status
        };
    }
}
