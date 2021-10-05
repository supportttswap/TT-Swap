using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Utilities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace BeCoreApp.Application.Interfaces
{
    public interface IWalletBNBBEP20TransactionService
    {
        PagedResult<WalletBNBBEP20TransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize);

        void Add(WalletBNBBEP20TransactionViewModel Model);

        void Save();
    }
}
