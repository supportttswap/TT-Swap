using BeCoreApp.Application.Interfaces;
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
    public class TicketTransactionService : ITicketTransactionService
    {
        private readonly ITicketTransactionRepository _ticketTransactionRepository;
        private readonly IWalletBNBBEP20TransactionService _walletBNBBEP20TransactionService;
        private readonly IWalletBNBAffiliateTransactionService _walletBNBAffiliateTransactionService;
        private readonly IWalletInvestTransactionService _walletInvestTransactionService;
        private readonly IWalletLockTransactionService _walletLockTransactionService;
        private readonly IBlockChainService _blockChainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public TicketTransactionService(
            IWalletLockTransactionService walletLockTransactionService,
            IWalletInvestTransactionService walletInvestTransactionService,
            IWalletBNBAffiliateTransactionService walletBNBAffiliateTransactionService,
            IWalletBNBBEP20TransactionService walletBNBBEP20TransactionService,
            UserManager<AppUser> userManager,
            IBlockChainService blockChainService,
            ITicketTransactionRepository ticketTransactionRepository,
            IUnitOfWork unitOfWork)
        {
            _walletLockTransactionService = walletLockTransactionService;
            _walletInvestTransactionService = walletInvestTransactionService;
            _walletBNBAffiliateTransactionService = walletBNBAffiliateTransactionService;
            _walletBNBBEP20TransactionService = walletBNBBEP20TransactionService;

            _blockChainService = blockChainService;
            _userManager = userManager;
            _ticketTransactionRepository = ticketTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        public PagedResult<TicketTransactionViewModel> GetAllPaging(string keyword, string appUserId, int pageIndex, int pageSize)
        {
            var query = _ticketTransactionRepository.FindAll(x => x.AppUser);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.AddressFrom.Contains(keyword)
                || x.AddressTo.Contains(keyword)
                || x.AppUser.Email.Contains(keyword)
                || x.AppUser.Sponsor.Value.ToString().Contains(keyword));

            if (!string.IsNullOrWhiteSpace(appUserId))
                query = query.Where(x => x.AppUserId.ToString() == appUserId);

            var totalRow = query.Count();
            var data = query.OrderBy(x => x.Status).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Select(x => new TicketTransactionViewModel()
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
                    Type = x.Type,
                    TypeName = x.Type.GetDescription(),
                    Status = x.Status,
                    StatusName = x.Status.GetDescription(),
                    Unit = x.Unit,
                    UnitName = x.Unit.GetDescription(),
                    DateCreated = x.DateCreated,
                    DateUpdated = x.DateUpdated
                }).ToList();

            return new PagedResult<TicketTransactionViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public void Add(TicketTransactionViewModel model)
        {
            var transaction = new TicketTransaction()
            {
                AddressFrom = model.AddressFrom,
                AddressTo = model.AddressTo,

                Fee = model.Fee,
                FeeAmount = model.FeeAmount,
                AmountReceive = model.AmountReceive,
                Amount = model.Amount,

                AppUserId = model.AppUserId,
                Unit = model.Unit,
                Status = model.Status,
                Type = model.Type,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            _ticketTransactionRepository.Add(transaction);
        }

        public async Task Rejected(int id)
        {
            var ticketTransaction = _ticketTransactionRepository.FindById(id);

            ticketTransaction.Status = TicketTransactionStatus.Rejected;
            ticketTransaction.DateUpdated = DateTime.Now;
            _ticketTransactionRepository.Update(ticketTransaction);
            _unitOfWork.Commit();

            var appUser = await _userManager.FindByIdAsync(ticketTransaction.AppUserId.ToString());

            if (ticketTransaction.Type == TicketTransactionType.WithdrawBNBBEP20)
            {
                appUser.MainBalance += ticketTransaction.Amount;
                await _userManager.UpdateAsync(appUser);
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawBNBAffiliate)
            {
                appUser.BNBAffiliateBalance += ticketTransaction.Amount;
                await _userManager.UpdateAsync(appUser);
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawTTSAffiliate)
            {
                appUser.TTSAffiliateBalance += ticketTransaction.Amount;
                await _userManager.UpdateAsync(appUser);
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawTTSCommission)
            {
                appUser.TTSCommissionBalance += ticketTransaction.Amount;
                await _userManager.UpdateAsync(appUser);
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawInvest)
            {
                appUser.InvestBalance += ticketTransaction.Amount;
                await _userManager.UpdateAsync(appUser);
            }
            else
            {
                appUser.LockBalance += ticketTransaction.Amount;
                await _userManager.UpdateAsync(appUser);
            }
        }

        public async Task<GenericResult> Approved(int id)
        {

            var ticketTransaction = _ticketTransactionRepository.FindById(id);

            if (ticketTransaction.Type == TicketTransactionType.WithdrawBNBBEP20)
            {
                decimal payAffiliateBalance = await _blockChainService
                    .GetEtherBalance(CommonConstants.BEP20PAYAFFILIATEPuKey, CommonConstants.BEP20Url);

                if (payAffiliateBalance <= ticketTransaction.AmountReceive)
                {
                    return new GenericResult(false, "Your balance is not enough to make a transaction");
                }

                decimal balanceTransfer = ticketTransaction.AmountReceive;

                var transaction = await _blockChainService
                        .SendEthAsync(CommonConstants.BEP20PAYAFFILIATEPrKey, ticketTransaction.AddressTo,
                        balanceTransfer, CommonConstants.BEP20Url);

                if (transaction.HasErrors() != true)
                {
                    var walletBNBBEP20Transaction = new WalletBNBBEP20TransactionViewModel
                    {
                        AppUserId = ticketTransaction.AppUserId,
                        AddressFrom = CommonConstants.BEP20PAYAFFILIATEPuKey,
                        AddressTo = ticketTransaction.AddressTo,

                        Amount = ticketTransaction.Amount,
                        FeeAmount = ticketTransaction.FeeAmount,
                        Fee = ticketTransaction.Fee,
                        AmountReceive = ticketTransaction.AmountReceive,

                        TransactionHash = transaction.TransactionHash,
                        Type = WalletBNBBEP20TransactionType.Withdraw,
                        DateCreated = DateTime.Now
                    };

                    _walletBNBBEP20TransactionService.Add(walletBNBBEP20Transaction);
                    _walletBNBBEP20TransactionService.Save();
                }
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawBNBAffiliate)
            {
                decimal payAffiliateBalance = await _blockChainService
                    .GetEtherBalance(CommonConstants.BEP20PAYAFFILIATEPuKey, CommonConstants.BEP20Url);

                if (payAffiliateBalance <= ticketTransaction.AmountReceive)
                {
                    return new GenericResult(false, "Your balance is not enough to make a transaction");
                }

                decimal balanceTransfer = ticketTransaction.AmountReceive;

                var transaction = await _blockChainService
                        .SendEthAsync(CommonConstants.BEP20PAYAFFILIATEPrKey, ticketTransaction.AddressTo,
                        balanceTransfer, CommonConstants.BEP20Url);

                if (transaction.HasErrors() != true)
                {
                    var walletBNBAffiliateTransaction = new WalletBNBAffiliateTransactionViewModel
                    {
                        AppUserId = ticketTransaction.AppUserId,
                        AddressFrom = CommonConstants.BEP20PAYAFFILIATEPuKey,
                        AddressTo = ticketTransaction.AddressTo,

                        Amount = ticketTransaction.Amount,
                        FeeAmount = ticketTransaction.FeeAmount,
                        Fee = ticketTransaction.Fee,
                        AmountReceive = ticketTransaction.AmountReceive,

                        TransactionHash = transaction.TransactionHash,
                        Type = WalletBNBAffiliateTransactionType.Withdraw,
                        DateCreated = DateTime.Now
                    };

                    _walletBNBAffiliateTransactionService.Add(walletBNBAffiliateTransaction);
                    _walletBNBAffiliateTransactionService.Save();
                }

            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawTTSAffiliate)
            {
                //decimal exchangeBalance = await _blockChainService
                //    .GetERC20Balance(CommonConstants.BEP20EXCHANGEPuKey, CommonConstants.BEP20TTSContract,
                //    CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                //if (exchangeBalance < ticketTransaction.AmountReceive)
                //{
                //    return new GenericResult(false, "Your balance is not enough to make a transaction");
                //}
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawTTSCommission)
            {
                //decimal exchangeBalance = await _blockChainService
                //    .GetERC20Balance(CommonConstants.BEP20EXCHANGEPuKey, CommonConstants.BEP20TTSContract,
                //    CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                //if (exchangeBalance < ticketTransaction.AmountReceive)
                //{
                //    return new GenericResult(false, "Your balance is not enough to make a transaction");
                //}
            }
            else if (ticketTransaction.Type == TicketTransactionType.WithdrawInvest)
            {
                decimal exchangeBalance = await _blockChainService
                    .GetERC20Balance(CommonConstants.BEP20EXCHANGEPuKey, CommonConstants.BEP20TTSContract,
                    CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                if (exchangeBalance < ticketTransaction.AmountReceive)
                {
                    return new GenericResult(false, "Your balance is not enough to make a transaction");
                }

                decimal balanceTransfer = ticketTransaction.AmountReceive;

                var transaction = await _blockChainService
                        .SendERC20Async(CommonConstants.BEP20EXCHANGEPrKey,
                        ticketTransaction.AddressTo,
                        CommonConstants.BEP20TTSContract, balanceTransfer,
                        CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                if (!string.IsNullOrWhiteSpace(transaction))
                {
                    var walletInvestTransaction = new WalletInvestTransactionViewModel
                    {
                        AppUserId = ticketTransaction.AppUserId,
                        AddressFrom = CommonConstants.BEP20EXCHANGEPuKey,
                        AddressTo = ticketTransaction.AddressTo,

                        Amount = ticketTransaction.Amount,
                        FeeAmount = ticketTransaction.FeeAmount,
                        Fee = ticketTransaction.Fee,
                        AmountReceive = ticketTransaction.AmountReceive,

                        TransactionHash = transaction,
                        Type = WalletInvestTransactionType.Withdraw,
                        DateCreated = DateTime.Now
                    };

                    _walletInvestTransactionService.Add(walletInvestTransaction);
                    _walletInvestTransactionService.Save();
                }
            }
            else
            {
                //decimal exchangeBalance = await _blockChainService
                //    .GetERC20Balance(CommonConstants.BEP20EXCHANGEPuKey, CommonConstants.BEP20TTSContract,
                //    CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                //if (exchangeBalance < ticketTransaction.AmountReceive)
                //{
                //    return new GenericResult(false, "Your balance is not enough to make a transaction");
                //}

                //decimal balanceTransfer = ticketTransaction.AmountReceive;

                //var transaction = await _blockChainService
                //        .SendERC20Async(CommonConstants.BEP20EXCHANGEPrKey, ticketTransaction.AddressTo,
                //        CommonConstants.BEP20TTSContract, balanceTransfer,
                //        CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                //if (!string.IsNullOrWhiteSpace(transaction))
                //{
                //    var walletLockTransaction = new WalletLockTransactionViewModel
                //    {
                //        AppUserId = ticketTransaction.AppUserId,
                //        AddressFrom = CommonConstants.BEP20EXCHANGEPuKey,
                //        AddressTo = ticketTransaction.AddressTo,

                //        Amount = ticketTransaction.Amount,
                //        FeeAmount = ticketTransaction.FeeAmount,
                //        Fee = ticketTransaction.Fee,
                //        AmountReceive = ticketTransaction.AmountReceive,

                //        TransactionHash = transaction,
                //        Type = WalletLockTransactionType.Withdraw,
                //        DateCreated = DateTime.Now
                //    };

                //    _walletLockTransactionService.Add(walletLockTransaction);
                //    _walletLockTransactionService.Save();
                //}
            }

            ticketTransaction.Status = TicketTransactionStatus.Approved;
            ticketTransaction.DateUpdated = DateTime.Now;
            _ticketTransactionRepository.Update(ticketTransaction);
            _unitOfWork.Commit();

            return new GenericResult(true, "Approve ticket is success", ticketTransaction);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
