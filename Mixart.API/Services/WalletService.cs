using Mixart.API.Domain.Entities;
using Mixart.API.Repositories;

namespace Mixart.API.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Wallet?> GetByArtistIdAsync(int artistId)
    {
        return await _walletRepository.GetByArtistIdAsync(artistId);
    }

    public async Task<Wallet> CreateOrUpdateAsync(Wallet wallet)
    {
        var existing = await _walletRepository.GetByArtistIdAsync(wallet.ArtistId);

        if (existing == null)
        {
            await _walletRepository.AddAsync(wallet);
            return wallet;
        }

        existing.Balance = wallet.Balance;

        await _walletRepository.UpdateAsync(existing);
        return existing;
    }
}