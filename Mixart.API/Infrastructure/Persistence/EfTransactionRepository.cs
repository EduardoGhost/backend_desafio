using Microsoft.EntityFrameworkCore;
using Mixart.API.Domain.Entities;
using Mixart.API.Repositories;

namespace Mixart.API.Infrastructure.Persistence
{
    public class EfTransactionRepository : ITransactionRepository
    {
        private readonly MixartDbContext _db;

        public EfTransactionRepository(MixartDbContext db) => _db = db;

        public async Task AddAsync(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId)
        {
            return await _db.Transactions
                .Where(t => t.WalletId == walletId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _db.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}