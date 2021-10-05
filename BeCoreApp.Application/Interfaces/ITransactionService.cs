using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeCoreApp.Application.Interfaces
{
    public interface ITransactionService
    {
        PagedResult<TransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize);
        decimal GetUserAmountByType(Guid appUserId, TransactionType type);
        int CountByType(string appUserId, TransactionType type);
        int CountByType(TransactionType type);
        void Add(TransactionViewModel Model);

        void Save();
    }
}
