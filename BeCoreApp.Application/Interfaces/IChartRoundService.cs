using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Utilities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace BeCoreApp.Application.Interfaces
{
    public interface IChartRoundService
    {
        List<ChartRoundViewModel> GetAll();

        ChartRoundViewModel GetByType(ChartRoundType type);

        void Update(ChartRoundViewModel Model);

        void Save();
    }
}
