using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Utilities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace BeCoreApp.Application.Interfaces
{
    public interface IWalletLockTransactionService
    {
        PagedResult<WalletLockTransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize);

        void Add(WalletLockTransactionViewModel Model);

        void Save();
    }
}
