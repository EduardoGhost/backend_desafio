using Mixart.API.Domain.Entities;

namespace Mixart.API.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsByWalletAsync(Guid walletId);

        // NOVOS MÉTODOS
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(Guid id);
    }
}