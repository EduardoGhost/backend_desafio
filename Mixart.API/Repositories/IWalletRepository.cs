using Mixart.API.Domain.Entities;

namespace Mixart.API.Repositories
{
    public interface IWalletRepository
    {
        Task AddAsync(Wallet wallet);
        Task UpdateAsync(Wallet wallet);

        Task<Wallet?> GetByIdAsync(Guid id);
        Task<IEnumerable<Wallet>> GetAllAsync();
        Task<Wallet?> GetByArtistIdAsync(int artistId);
    }
}