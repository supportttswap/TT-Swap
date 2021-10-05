using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using System;
using System.Linq;

namespace BeCoreApp.Application.Implementation
{
    public class WalletInvestTransactionService
        : IWalletInvestTransactionService
    {
        private readonly IWalletInvestTransactionRepository _walletInvestTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WalletInvestTransactionService(
            IWalletInvestTransactionRepository walletInvestTransactionRepository,
            IUnitOfWork unitOfWork)
        {
            _walletInvestTransactionRepository = walletInvestTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        public PagedResult<WalletInvestTransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize)
        {
            var query = _walletInvestTransactionRepository.FindAll(x => x.AppUser);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.TransactionHash.Contains(keyword)
                || x.AddressFrom.Contains(keyword)
                || x.AddressTo.Contains(keyword)
                || x.AppUser.Email.Contains(keyword)
                || x.AppUser.Sponsor.Value.ToString().Contains(keyword));

            if (!string.IsNullOrWhiteSpace(appUserId))
                query = query.Where(x => x.AppUserId.ToString() == appUserId);

            var totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Select(x => new WalletInvestTransactionViewModel()
                {
                    Id = x.Id,
                    AddressFrom = x.AddressFrom,
                    AddressTo = x.AddressTo,

                    Fee = x.Fee,
                    FeeAmount = x.FeeAmount,
                    AmountReceive = x.AmountReceive,
                    Amount = x.Amount,

                    StrAmount = x.Amount.ToString(),
                    AppUserId = x.AppUserId,
                    AppUserName = x.AppUser.UserName,
                    Sponsor = $"TTS{ x.AppUser.Sponsor}",
                    DateCreated = x.DateCreated,
                    TransactionHash = x.TransactionHash,
                    Type = x.Type,
                    TypeName = x.Type.GetDescription()
                }).ToList();

            return new PagedResult<WalletInvestTransactionViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public void Add(WalletInvestTransactionViewModel model)
        {
            var transaction = new WalletInvestTransaction()
            {
                AddressFrom = model.AddressFrom,
                AddressTo = model.AddressTo,

                Fee = model.Fee,
                FeeAmount = model.FeeAmount,
                AmountReceive = model.AmountReceive,
                Amount = model.Amount,

                AppUserId = model.AppUserId,
                DateCreated = model.DateCreated,
                TransactionHash = model.TransactionHash,
                Type = model.Type
            };

            _walletInvestTransactionRepository.Add(transaction);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
