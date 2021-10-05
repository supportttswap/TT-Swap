using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Enums;
using System;

namespace BeCoreApp.Application.ViewModels.Game
{
    public class LuckyRoundHistoryViewModel
    {
        public int Id { get; set; }

        public string AddressFrom { get; set; }

        public string AddressTo { get; set; }

        public decimal Amount { get; set; }

        public LuckyRoundHistoryUnit Unit { get; set; }

        public LuckyRoundHistoryType Type { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int LuckyRoundId { get; set; }

        public Guid AppUserId { get; set; }

        public AppUserViewModel AppUser { set; get; }

        public LuckyRoundViewModel LuckyRound { set; get; }

    }
}
