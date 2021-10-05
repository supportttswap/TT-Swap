using BeCoreApp.Data.Enums;
using BeCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeCoreApp.Data.Entities
{
    [Table("MetamaskTransactions")]
    public class MetamaskTransaction : DomainEntity<Guid>
    {
        public string AddressTo { get; set; }
        public string AddressFrom { get; set; }
        public MetaMaskState MetaMaskState { get; set; }
        public MetaMaskTransactionType Type { get; set; }
        public decimal BNBAmount { get; set; }
        public decimal TTSAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string BNBTransactionHash { get; set; }
        public string TTSTransactionHash { get; set; }
    }
}
