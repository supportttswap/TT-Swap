using BeCoreApp.Application.ViewModels.Report;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Utilities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace BeCoreApp.Application.Interfaces
{
    public interface IReportService
    {
        ReportViewModel GetReportInfo(string startDate, string endDate);
    }
}
