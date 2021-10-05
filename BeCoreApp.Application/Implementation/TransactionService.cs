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
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        private IUnitOfWork _unitOfWork;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public PagedResult<TransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize)
        {
            var query = _transactionRepository.FindAll(x => x.AppUser);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.TransactionHash.Contains(keyword)
                || x.AddressTo.Contains(keyword)
                || x.AppUser.Email.Contains(keyword)
                || x.AppUser.Sponsor.Value.ToString().Contains(keyword));

            if (!string.IsNullOrWhiteSpace(appUserId))
                query = query.Where(x => x.AppUserId.ToString() == appUserId);

            var totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Select(x => new TransactionViewModel()
                {
                    Id = x.Id,
                    AddressTo = x.AddressTo,
                    Amount = x.Amount,
                    StrAmount = x.Amount.ToString(),
                    AppUserId = x.AppUserId,
                    AppUserName = x.AppUser.UserName,
                    Sponsor = $"TTS{ x.AppUser.Sponsor}",
                    DateCreated = x.DateCreated,
                    TransactionHash = x.TransactionHash,
                    Unit = x.Unit,
                    UnitName = x.Unit.GetDescription(),
                    Type = x.Type,
                    TypeName = x.Type.GetDescription()
                }).ToList();

            return new PagedResult<TransactionViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public decimal GetUserAmountByType(Guid appUserId, TransactionType type)
        {
            var query = _transactionRepository
                .FindAll(x => x.AppUserId == appUserId && x.Type == type).ToList();

            decimal amount = query.Sum(x => x.Amount);

            return amount;
        }

        public int CountByType(string appUserId, TransactionType type)
        {
            var countItem = _transactionRepository
                .FindAll(x => x.AppUserId == new Guid(appUserId) && x.Type == type).Count();

            return countItem;
        }

        public int CountByType(TransactionType type)
        {
            var countItem = _transactionRepository.FindAll(x => x.Type == type).Count();
            return countItem;
        }

        public void Add(TransactionViewModel model)
        {
            var transaction = new CustomerTransaction()
            {
                AddressFrom = model.AddressFrom,
                AddressTo = model.AddressTo,
                Amount = model.Amount,
                AppUserId = model.AppUserId,
                DateCreated = model.DateCreated,
                TransactionHash = model.TransactionHash,
                Unit = model.Unit,
                Type = model.Type,
            };

            _transactionRepository.Add(transaction);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
