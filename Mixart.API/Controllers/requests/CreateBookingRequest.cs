namespace Mixart.API.Controllers.Requests;

public class CreateBookingRequest
{
    public int ArtistId { get; set; }
    public int ContractorId { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }

    public decimal TotalValue { get; set; }
}
