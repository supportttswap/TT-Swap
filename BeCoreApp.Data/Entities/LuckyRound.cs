using BeCoreApp.Data.Enums;
using BeCoreApp.Data.Interfaces;
using BeCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeCoreApp.Data.Entities
{
    [Table("LuckyRounds")]
    public class LuckyRound : DomainEntity<int>
    {
        [Required]
        public LuckyRoundStatus Status { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<LuckyRoundHistory> LuckyRoundHistories { get; set; }
    }
}
