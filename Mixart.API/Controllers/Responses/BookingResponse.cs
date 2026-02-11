using Mixart.API.Domain.Enums;

namespace Mixart.API.Controllers.Responses;

public class BookingResponse
{
    public Guid Id { get; set; }
    public int ArtistId { get; set; }
    public int ContractorId { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }

    public decimal TotalValue { get; set; }
    public BookingStatus Status { get; set; }
}
