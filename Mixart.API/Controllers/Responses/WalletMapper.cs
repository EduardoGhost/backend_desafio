using Mixart.API.Domain.Entities;
using Mixart.API.Responses;

namespace Mixart.API.Mappers;

public static class WalletMapper
{
    public static WalletResponse ToResponse(this Wallet wallet) =>
        new WalletResponse
        {
            Id = wallet.Id,
            ArtistId = wallet.ArtistId,
            Balance = wallet.Balance
        };
}
