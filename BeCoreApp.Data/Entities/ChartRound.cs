using BeCoreApp.Data.Enums;
using BeCoreApp.Data.Interfaces;
using BeCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeCoreApp.Data.Entities
{
    [Table("ChartRounds")]
    public class ChartRound : DomainEntity<int>
    {
        [Required]
        public decimal DistributedToken { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public ChartRoundType Type { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }
    }
}
