using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Dtos;
using System.Linq;

namespace BeCoreApp.Application.Implementation
{
    public class WalletTransferService : IWalletTransferService
    {
        private readonly IWalletTransferRepository _walletTransferRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WalletTransferService
            (
            IWalletTransferRepository walletTransferRepository,
            IUnitOfWork unitOfWork
            )
        {
            _walletTransferRepository = walletTransferRepository;
            _unitOfWork = unitOfWork;
        }

        public PagedResult<WalletTransferViewModel> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            var query = _walletTransferRepository.FindAll();

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.PrivateKey.Contains(keyword) 
                || x.PublishKey.Contains(keyword)
                || x.TransactionHash.Contains(keyword));

            var totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Select(x => new WalletTransferViewModel()
                {
                    Id = x.Id,
                    PrivateKey = x.PrivateKey,
                    PublishKey = x.PublishKey,
                    DateCreated = x.DateCreated,
                    TransactionHash = x.TransactionHash,
                    Amount = x.Amount
                }).ToList();

            return new PagedResult<WalletTransferViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public void Add(WalletTransferViewModel model)
        {
            var transaction = new WalletTransfer()
            {
                PrivateKey = model.PrivateKey,
                PublishKey = model.PublishKey,
                TransactionHash = model.TransactionHash,
                DateCreated = model.DateCreated,
                Amount = model.Amount
            };

            _walletTransferRepository.Add(transaction);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
