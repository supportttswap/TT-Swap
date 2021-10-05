using BeCoreApp.Data.Enums;
using BeCoreApp.Data.Interfaces;
using BeCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeCoreApp.Data.Entities
{
    [Table("LuckyRoundHistories")]
    public class LuckyRoundHistory : DomainEntity<int>
    {
        [Required]
        public string AddressFrom { get; set; }

        [Required]
        public string AddressTo { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public LuckyRoundHistoryUnit Unit { get; set; }

        [Required]
        public LuckyRoundHistoryType Type { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public int LuckyRoundId { get; set; }

        [Required]
        public Guid AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { set; get; }

        [ForeignKey("LuckyRoundId")]
        public virtual LuckyRound LuckyRound { set; get; }
    }
}
