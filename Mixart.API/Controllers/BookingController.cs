using Microsoft.AspNetCore.Mvc;
using Mixart.API.Services;
using Mixart.API.Controllers.Responses;
using Mixart.API.Controllers.Requests;

namespace Mixart.API.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingsController(IBookingService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingRequest request)
    {
        var booking = await _service.CreateAsync(
            request.ArtistId,
            request.ContractorId,
            request.Date,
            request.StartTime,
            request.TotalValue
        );

        return Created("", booking.ToResponse());
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await _service.GetAll();
        return Ok(bookings.Select(b => b.ToResponse()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var booking = await _service.GetById(id);
            return Ok(booking.ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("{id}/accept")]
    public async Task<IActionResult> Accept(Guid id)
    {
        try
        {
            var booking = await _service.Accept(id);
            return Ok(booking.ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/reject")]
    public async Task<IActionResult> Reject(Guid id)
    {
        try
        {
            var booking = await _service.Reject(id);
            return Ok(booking.ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}