using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Game;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Implementation
{
    public class LuckyRoundHistoryService : ILuckyRoundHistoryService
    {
        private readonly ILuckyRoundHistoryRepository _luckyRoundHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LuckyRoundHistoryService(
            ILuckyRoundHistoryRepository luckyRoundHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            _luckyRoundHistoryRepository = luckyRoundHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public int CountByType(LuckyRoundHistoryType type)
        {
            int countItem = _luckyRoundHistoryRepository.FindAll(x => x.Type == type).Count();
            return countItem;
        }

        public void Add(LuckyRoundHistoryViewModel Vm)
        {
            var model = new LuckyRoundHistory()
            {
                Id = Vm.Id,
                DateCreated = Vm.DateCreated,
                DateUpdated = Vm.DateUpdated,
                AddressFrom = Vm.AddressFrom,
                AddressTo = Vm.AddressTo,
                Amount = Vm.Amount,
                AppUserId = Vm.AppUserId,
                LuckyRoundId = Vm.LuckyRoundId,
                Unit = Vm.Unit,
                Type = Vm.Type
            };

            _luckyRoundHistoryRepository.Add(model);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
