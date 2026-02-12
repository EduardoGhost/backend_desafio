using Mixart.API.Domain.Entities;     
using Mixart.API.Infrastructure.Persistence;       
using Microsoft.EntityFrameworkCore;   


namespace Mixart.API.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly MixartDbContext _context;

        public WalletRepository(MixartDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet?> GetByArtistIdAsync(int artistId)
            => await _context.Wallets
                .FirstOrDefaultAsync(w => w.ArtistId == artistId);

        public async Task<Wallet?> GetByIdAsync(Guid id)
            => await _context.Wallets
                .FirstOrDefaultAsync(w => w.Id == id);

        public async Task<IEnumerable<Wallet>> GetAllAsync()
            => await _context.Wallets.ToListAsync();

        public async Task AddAsync(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
