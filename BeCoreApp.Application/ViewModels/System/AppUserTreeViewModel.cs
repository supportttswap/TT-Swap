using BeCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace BeCoreApp.Application.ViewModels.System
{
    public class AppUserTreeViewModel
    {
        public AppUserTreeViewModel()
        {
            children = new List<AppUserTreeViewModel>();
        }

        public Guid id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public AppUserTreeData data { get; set; }
        public AppUserTreeState state { get; set; }

        public List<AppUserTreeViewModel> children { get; set; }
    }

    public class AppUserTreeState
    {
        public bool opened { get; set; } = true;
    }

    public class AppUserTreeData
    {
        public Guid rootId { get; set; }

        public string sponsor { get; set; }

        public Guid? referralId { get; set; }

        public decimal investBalance { get; set; }

        public decimal lockBalance { get; set; }

        public decimal affiliateBalance { get; set; }

        public decimal stakingBalance { get; set; }

        public string email { set; get; }

        public bool isSystem { get; set; } = false;

        public bool emailConfirmed { get; set; }

        public DateTime dateCreated { get; set; }

        public Status status { get; set; }
    }
}
