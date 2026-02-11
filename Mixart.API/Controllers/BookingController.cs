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
    public IActionResult Create(CreateBookingRequest request)
    {
        var booking = _service.Create(
            request.ArtistId,
            request.ContractorId,
            request.Date,
            request.StartTime,
            request.TotalValue
        );

        return Created("", booking.ToResponse());
    }



    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAll().Select(b => b.ToResponse()));
        


    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_service.GetById(id).ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpPut("{id}/accept")]
    public IActionResult Accept(Guid id)
    {
        try
        {
            return Ok(_service.Accept(id).ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/reject")]
    public IActionResult Reject(Guid id)
    {
        try
        {
            return Ok(_service.Reject(id).ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _service.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
