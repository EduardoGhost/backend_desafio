using Mixart.API.Domain.Entities;

namespace Mixart.API.Services;

public interface IWalletService
{
    Task<Wallet?> GetByArtistIdAsync(int artistId);
    Task<Wallet> CreateOrUpdateAsync(Wallet wallet);
}
