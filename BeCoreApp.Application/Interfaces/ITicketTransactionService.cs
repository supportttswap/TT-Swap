using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Utilities.Dtos;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Interfaces
{
    public interface ITicketTransactionService
    {
        PagedResult<TicketTransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize);
        void Add(TicketTransactionViewModel Model);
        Task Rejected(int id);
        Task<GenericResult> Approved(int id);
        void Save();
    }
}
