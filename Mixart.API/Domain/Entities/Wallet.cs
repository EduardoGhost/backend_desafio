using System;
using System.ComponentModel.DataAnnotations;

namespace Mixart.API.Domain.Entities
{
    public class Wallet
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int ArtistId { get; set; }

        public decimal Balance { get; set; } = 0;
    }
}
