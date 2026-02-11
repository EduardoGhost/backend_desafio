using Microsoft.EntityFrameworkCore;
using Mixart.API.Domain.Entities;
using Mixart.API.Repositories; 
using System.Threading.Tasks;

namespace Mixart.API.Infrastructure.Persistence
{
    public class EfWalletRepository : IWalletRepository
    {
        private readonly MixartDbContext _db;

        public EfWalletRepository(MixartDbContext db) => _db = db;

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
}
