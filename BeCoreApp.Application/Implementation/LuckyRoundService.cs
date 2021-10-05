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
    public class LuckyRoundService : ILuckyRoundService
    {
        private readonly ILuckyRoundRepository _luckyRoundRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public LuckyRoundService(
            ILuckyRoundRepository luckyRoundRepository,
            UserManager<AppUser> userManager,
            IUnitOfWork unitOfWork)
        {
            _luckyRoundRepository = luckyRoundRepository;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        public LuckyRoundViewModel GetProcess()
        {
            LuckyRound luckyRoundProcess = _luckyRoundRepository
                .FindAll(x => x.Status == LuckyRoundStatus.Process).FirstOrDefault();

            if (luckyRoundProcess == null)
            {
                luckyRoundProcess = new LuckyRound()
                {
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Status = LuckyRoundStatus.Process
                };

                _luckyRoundRepository.Add(luckyRoundProcess);
                _unitOfWork.Commit();
            }

            return new LuckyRoundViewModel
            {
                Id = luckyRoundProcess.Id,
                Status = luckyRoundProcess.Status,
                DateCreated = luckyRoundProcess.DateCreated,
                DateUpdated = luckyRoundProcess.DateUpdated
            };
        }

        public void Update(LuckyRoundViewModel vm)
        {
            var luckyRound = _luckyRoundRepository.FindById(vm.Id);

            luckyRound.Status = vm.Status;
            luckyRound.DateUpdated = vm.DateUpdated;

            _luckyRoundRepository.Update(luckyRound);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
