using BeCoreApp.Application.ViewModels.Game;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Enums;
using BeCoreApp.Utilities.Dtos;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Interfaces
{
    public interface ILuckyRoundHistoryService
    {
        int CountByType(LuckyRoundHistoryType type);

        void Add(LuckyRoundHistoryViewModel model);

        void Save();
    }
}
