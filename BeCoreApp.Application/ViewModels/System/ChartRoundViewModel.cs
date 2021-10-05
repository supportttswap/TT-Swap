using BeCoreApp.Data.Enums;
using System;

namespace BeCoreApp.Application.ViewModels.System
{
    public class ChartRoundViewModel
    {
        public int Id { get; set; }
        public decimal DistributedToken { get; set; }

        public decimal Total { get; set; }

        public ChartRoundType Type { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
