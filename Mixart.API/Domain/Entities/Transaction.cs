using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mixart.API.Domain.Entities
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid WalletId { get; set; }

        [ForeignKey("WalletId")]
        public Wallet? Wallet { get; set; }

        public Guid? BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking? Booking { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; } = TransactionType.Credit;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}