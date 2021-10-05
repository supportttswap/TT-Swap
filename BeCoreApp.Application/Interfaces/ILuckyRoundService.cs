using BeCoreApp.Application.ViewModels.Game;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Utilities.Dtos;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Interfaces
{
    public interface ILuckyRoundService
    {
        void Update(LuckyRoundViewModel vm);

        LuckyRoundViewModel GetProcess();
        void Save();
    }
}
