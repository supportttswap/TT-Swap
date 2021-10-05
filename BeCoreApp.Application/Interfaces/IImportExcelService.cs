using BeCoreApp.Application.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Interfaces
{
    public interface IImportExcelService
    {
        Task<List<MemberBalanceModel>> ExtractMemberBalanceFromFile(ImportExcelModel model);
    }
}
