using Mixart.API.Domain.Entities;

namespace Mixart.API.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId);
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(Guid id);
    }
}