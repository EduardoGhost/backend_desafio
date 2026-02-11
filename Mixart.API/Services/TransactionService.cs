using Mixart.API.Domain.Entities;
using Mixart.API.Repositories;

namespace Mixart.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;

        public TransactionService(ITransactionRepository repo) => _repo = repo;

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            await _repo.AddAsync(transaction);
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByWalletAsync(Guid walletId)
        {
            return await _repo.GetByWalletIdAsync(walletId);
        }

        // NOVOS MÉTODOS
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}