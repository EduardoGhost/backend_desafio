using Mixart.API.Domain.Entities;
using Mixart.API.Domain.Responses;

namespace Mixart.API.Domain.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionResponse ToResponse(this Transaction transaction) =>
            new TransactionResponse
            {
                Id = transaction.Id,
                WalletId = transaction.WalletId,
                BookingId = transaction.BookingId,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Description = transaction.Description,
                CreatedAt = transaction.CreatedAt
            };
    }
}