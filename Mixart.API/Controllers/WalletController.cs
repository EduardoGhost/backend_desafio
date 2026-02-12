using Microsoft.AspNetCore.Mvc;
using Mixart.API.Services;
using Mixart.API.Mappers;
using Mixart.API.Responses;
using Mixart.API.Domain.Entities;



namespace Mixart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletsController : ControllerBase
{
    private readonly IWalletService _service;

    public WalletsController(IWalletService service)
    {
        _service = service;
    }

    [HttpGet("{artistId}")]
    public async Task<ActionResult<WalletResponse>> GetWallet(int artistId)
    {
        var wallet = await _service.GetByArtistIdAsync(artistId);

        if (wallet == null)
            return NotFound();

        return Ok(wallet.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult<WalletResponse>> CreateWallet([FromBody] WalletRequest request)
    {
        var wallet = new Wallet
        {
            ArtistId = request.ArtistId,
            Balance = request.Balance
        };

        var result = await _service.CreateOrUpdateAsync(wallet);

        return CreatedAtAction(
            nameof(GetWallet),
            new { artistId = result.ArtistId },
            result.ToResponse()
        );
    }
}