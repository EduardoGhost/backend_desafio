using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mixart.API.Domain.Entities;
using Mixart.API.Infrastructure.Persistence;
using Mixart.API.Mappers;
using Mixart.API.Responses;


namespace Mixart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletsController : ControllerBase
{
    private readonly MixartDbContext _db;

    public WalletsController(MixartDbContext db) => _db = db;

    // GET: api/wallets/{artistId}
    [HttpGet("{artistId}")]
    public async Task<ActionResult<WalletResponse>> GetWallet(int artistId)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.ArtistId == artistId);
        if (wallet == null) return NotFound();
        return wallet.ToResponse();
    }

    // POST: api/wallets
    [HttpPost]
    public async Task<ActionResult<WalletResponse>> CreateWallet([FromBody] WalletRequest request)
    {
        var wallet = new Wallet
        {
            Id = Guid.NewGuid(),
            ArtistId = request.ArtistId,
            Balance = request.Balance
        };

        _db.Wallets.Add(wallet);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWallet), new { artistId = wallet.ArtistId }, wallet.ToResponse());
    }
}
