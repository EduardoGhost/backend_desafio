using Mixart.API.Domain.Entities;     
using Mixart.API.Infrastructure.Persistence; 
using Mixart.API.Repositories;       
using Microsoft.EntityFrameworkCore;   
using System.Threading.Tasks;

public class WalletRepository : IWalletRepository
{
    private readonly MixartDbContext _db;

    public WalletRepository(MixartDbContext db) => _db = db;

    public async Task<Wallet?> GetByArtistIdAsync(int artistId) =>
        await _db.Wallets.FirstOrDefaultAsync(w => w.ArtistId == artistId);

    public async Task AddAsync(Wallet wallet)
    {
        _db.Wallets.Add(wallet);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _db.Wallets.Update(wallet);
        await _db.SaveChangesAsync();
    }
}
