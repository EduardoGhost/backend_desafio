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
        => await _walletRepository.GetByArtistIdAsync(artistId);

    public async Task<Wallet> CreateOrUpdateAsync(Wallet wallet)
    {
        var existing = await _walletRepository.GetByArtistIdAsync(wallet.ArtistId);
        if (existing != null)
        {
            existing.Balance = wallet.Balance; // Atualiza balance
            await _walletRepository.UpdateAsync(existing);
            return existing;
        }

        await _walletRepository.AddAsync(wallet); // Cria nova Wallet
        return wallet;
    }
}
