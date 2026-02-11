using System;
using Mixart.API.Domain.Entities;

namespace Mixart.API.Domain.Responses
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public Guid? BookingId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}