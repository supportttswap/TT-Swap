using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Utilities.Dtos;
using System.Collections.Generic;

namespace BeCoreApp.Application.Interfaces
{
    public interface INotifyService
    {
        PagedResult<NotifyViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize);

        List<NotifyViewModel> GetLast(int top);

        NotifyViewModel Add(NotifyViewModel blog);

        void Update(NotifyViewModel blog);

        NotifyViewModel GetById(int id);

        NotifyViewModel GetDashboard();

        void Delete(int id);

        void Save();
    }
}
