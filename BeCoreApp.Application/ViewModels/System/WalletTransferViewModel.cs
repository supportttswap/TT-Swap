﻿using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace BeCoreApp.Application.ViewModels.System
{
    public class WalletTransferViewModel
    {
        public WalletTransferViewModel()
        {
        }
        public int Id { get; set; }
        public string PrivateKey { get; set; }
        public string PublishKey { get; set; }
        public string TransactionHash { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
