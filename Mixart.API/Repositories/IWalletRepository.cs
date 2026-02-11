using Mixart.API.Domain.Entities;
using System.Threading.Tasks;

namespace Mixart.API.Repositories
{
    public interface IWalletRepository
    {
        Task<Wallet?> GetByArtistIdAsync(int artistId);
        Task AddAsync(Wallet wallet);
        Task UpdateAsync(Wallet wallet);
    }
}
