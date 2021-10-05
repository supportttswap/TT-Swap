using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Entities;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlockChainService _blockChainService;
        private readonly IAuthenticationService _authenticationService;
        public UserService(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IAuthenticationService authenticationService,
            IBlockChainService blockChainService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _blockChainService = blockChainService;
            _authenticationService = authenticationService;
        }

        #region Customer
        public StatementUserViewModel GetStatementUser(string keyword, int type)
        {
            var model = new StatementUserViewModel();

            var query = _userManager.Users.Where(x => x.IsSystem == false && x.EmailConfirmed == true
            && (x.InvestBalance > 0 || x.LockBalance > 0
            || x.MainBalance > 0 || x.BNBAffiliateBalance > 0
            || x.TTSAffiliateBalance > 0 || x.TTSCommissionBalance > 0));

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Email.Contains(keyword)
                || x.Sponsor.Value.ToString().Contains(keyword)
                || x.BNBBEP20PublishKey.Contains(keyword)
                || x.MainPublishKey.Contains(keyword));


            if (type == 1)
                query = query.Where(x => x.LockBalance > 0);
            else if (type == 2)
                query = query.Where(x => x.InvestBalance > 0);
            else if (type == 3)
                query = query.Where(x => x.MainBalance > 0);
            else if (type == 4)
                query = query.Where(x => x.BNBAffiliateBalance > 0);
            else if (type == 5)
                query = query.Where(x => x.TTSCommissionBalance > 0);
            else if (type == 6)
                query = query.Where(x => x.TTSAffiliateBalance > 0);

            query = query.Where(x => CommonConstants.MemberAccessDenied.Where(ma => ma.Email.ToLower() == x.Email.ToLower()).Count() == 0);


            model.AppUsers = query.Select(x => new AppUserViewModel()
            {
                Id = x.Id,
                Sponsor = $"TTS{x.Sponsor}",
                Email = x.Email,
                MainBalance = x.MainBalance,
                BNBAffiliateBalance = x.BNBAffiliateBalance,
                TTSAffiliateBalance = x.TTSAffiliateBalance,
                TTSCommissionBalance = x.TTSCommissionBalance,
                InvestBalance = x.InvestBalance,
                LockBalance = x.LockBalance,
                StakingBalance = x.StakingBalance,
            }).ToList();

            model.TotalMember = model.AppUsers.Count();
            model.TotalMainBalance = model.AppUsers.Sum(x => x.MainBalance);
            model.TotalBNBAffiliateBalance = model.AppUsers.Sum(x => x.BNBAffiliateBalance);
            model.TotalLockBalance = model.AppUsers.Sum(x => x.LockBalance);
            model.TotalInvestBalance = model.AppUsers.Sum(x => x.InvestBalance);
            model.TotalTTSAffiliateBalance = model.AppUsers.Sum(x => x.TTSAffiliateBalance);
            model.TotalTTSCommissionBalance = model.AppUsers.Sum(x => x.TTSCommissionBalance);

            return model;
        }

        public PagedResult<AppUserViewModel> GetAllCustomerPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _userManager.Users.Where(x => x.IsSystem == false);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Email.Contains(keyword)
                || x.Sponsor.Value.ToString().Contains(keyword)
                || x.BNBBEP20PublishKey.Contains(keyword)
                || x.MainPublishKey.Contains(keyword));

            int totalRow = query.Count();
            var data = query.Skip((page - 1) * pageSize).Take(pageSize)
                .Select(x => new AppUserViewModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    EmailConfirmed = x.EmailConfirmed,
                    Sponsor = $"TTS{x.Sponsor}",
                    Email = x.Email,
                    MainBalance = x.MainBalance,
                    BNBAffiliateBalance = x.BNBAffiliateBalance,
                    TTSAffiliateBalance = x.TTSAffiliateBalance,
                    TTSCommissionBalance = x.TTSCommissionBalance,
                    InvestBalance = x.InvestBalance,
                    BNBBEP20PublishKey = x.BNBBEP20PublishKey,
                    MainPublishKey = x.MainPublishKey,
                    LockBalance = x.LockBalance,
                    StakingBalance = x.StakingBalance,
                    Status = x.Status,
                    DateCreated = x.DateCreated,
                }).ToList();

            var paginationSet = new PagedResult<AppUserViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public async Task<NetworkViewModel> GetNetworkInfo(string id)
        {
            var customer = await _userManager.FindByIdAsync(id);

            var model = new NetworkViewModel();
            model.Email = customer.Email;
            model.Member = customer.UserName;
            model.Sponsor = $"TTS{customer.Sponsor}";
            model.EmailConfirmed = customer.EmailConfirmed;
            model.ReferalLink = $"https://tt-swap.net/register?sponsor=TTS{customer.Sponsor}";
            model.CreatedDate = customer.DateCreated;
            return model;
        }

        public async Task<NetworkViewModel> GetTotalNetworkInfo(string id)
        {
            var model = new NetworkViewModel();

            var customer = await _userManager.FindByIdAsync(id);

            var userList = _userManager.Users.Where(x => x.IsSystem == false);

            var f1Customers = userList.Where(x => x.ReferralId == customer.Id);
            var f1CustomerCount = f1Customers.Count();
            model.TotalF1 = f1CustomerCount;
            model.TotalMember = f1CustomerCount;

            if (f1CustomerCount > 0)
            {
                var f1CustomerIDs = f1Customers.Select(x => x.Id).ToList();

                var f2Customers = userList.Where(x => f1CustomerIDs.Contains(x.ReferralId.Value));
                var f2CustomerCount = f2Customers.Count();
                model.TotalF2 = f2CustomerCount;
                model.TotalMember += f2CustomerCount;

                if (f2CustomerCount > 0)
                {
                    var f2CustomerIDs = f2Customers.Select(x => x.Id).ToList();
                    var f3Customers = userList.Where(x => f2CustomerIDs.Contains(x.ReferralId.Value));
                    var f3CustomerCount = f3Customers.Count();
                    model.TotalF3 = f3CustomerCount;
                    model.TotalMember += f3CustomerCount;
                }
            }

            return model;
        }

        public PagedResult<AppUserViewModel> GetCustomerReferralPagingAsync(string customerId, int refIndex, string keyword, int page, int pageSize)
        {
            IQueryable<AppUser> dataCustomers = null;
            var userList = _userManager.Users.Where(x => x.IsSystem == false);

            if (!string.IsNullOrEmpty(keyword))
                userList = userList.Where(x => x.UserName.Contains(keyword) || x.Email.Contains(keyword));

            var f1Customers = userList.Where(x => x.ReferralId == new Guid(customerId));
            if (refIndex == 1)
            {
                dataCustomers = f1Customers;
            }
            else
            {
                var f1Ids = f1Customers.Select(x => x.Id).ToList();
                var f2Customers = userList.Where(x => f1Ids.Contains(x.ReferralId.Value));
                if (refIndex == 2)
                {
                    dataCustomers = f2Customers;
                }
                else
                {
                    var f2Ids = f2Customers.Select(x => x.Id).ToList();
                    var f3Customers = userList.Where(x => f2Ids.Contains(x.ReferralId.Value));
                    if (refIndex == 3)
                    {
                        dataCustomers = f3Customers;
                    }
                }
            }

            int totalRow = dataCustomers.Count();
            var data = dataCustomers.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize)
                .Select(x => new AppUserViewModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Sponsor = $"TTS{x.Sponsor}",
                    EmailConfirmed = x.EmailConfirmed,
                    Email = x.Email,
                    Status = x.Status,
                    ReferralId = x.ReferralId,
                    DateCreated = x.DateCreated
                }).ToList();

            return new PagedResult<AppUserViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
        }
        #endregion

        #region User System
        public PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _userManager.Users.Where(x => x.IsSystem);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.UserName.Contains(keyword) || x.Email.Contains(keyword));

            int totalRow = query.Count();
            var data = query.Skip((page - 1) * pageSize).Take(pageSize)
                .Select(x => new AppUserViewModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    Status = x.Status,
                    DateCreated = x.DateCreated
                }).ToList();

            var paginationSet = new PagedResult<AppUserViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public List<AppUserTreeViewModel> GetTreeAll()
        {
            var listData = _userManager.Users.OrderBy(x => x.Sponsor)
                .Select(x => new AppUserTreeViewModel()
                {
                    id = x.Id,
                    text = $"{x.Email}-{x.Sponsor}" +
                    $"-[{x.LockBalance}/{x.InvestBalance}" +
                    $"/{x.TTSAffiliateBalance}/{x.TTSCommissionBalance}" +
                    $"/{x.MainBalance}/{x.BNBAffiliateBalance}]",
                    icon = "fa fa-users text-success",
                    state = new AppUserTreeState { opened = true },
                    data = new AppUserTreeData
                    {
                        referralId = x.ReferralId,
                        rootId = x.Id,
                    }
                });

            if (listData.Count() == 0)
                return new List<AppUserTreeViewModel>();

            var groups = listData.GroupBy(i => i.data.referralId);

            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();

            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue)
                    .ToDictionary(g => g.Key.Value, g => g.ToList());

                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }
            return roots;
        }

        private void AddChildren(AppUserTreeViewModel root, IDictionary<Guid, List<AppUserTreeViewModel>> source)
        {
            if (source.ContainsKey(root.id))
            {
                root.children = source[root.id].ToList();
                for (int i = 0; i < root.children.Count; i++)
                    AddChildren(root.children[i], source);
            }
            else
            {
                root.icon = "fa fa-user text-danger";
                root.children = new List<AppUserTreeViewModel>();
            }
        }

        public async Task<AppUserViewModel> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);


            var userVm = new AppUserViewModel()
            {
                Id = user.Id,
                EmailConfirmed = user.EmailConfirmed,
                ReferralId = user.ReferralId,
                Enabled2FA = user.TwoFactorEnabled,
                MainPrivateKey = user.MainPrivateKey,
                MainPublishKey = user.MainPublishKey,
                MainBalance = user.MainBalance,

                BNBAffiliateBalance = user.BNBAffiliateBalance,
                LockBalance = user.LockBalance,
                InvestBalance = user.InvestBalance,
                TTSCommissionBalance = user.TTSCommissionBalance,
                TTSAffiliateBalance = user.TTSAffiliateBalance,
                StakingBalance = user.StakingBalance,
                StakingInterest = user.StakingInterest,

                BNBBEP20PublishKey = user.BNBBEP20PublishKey,
                ReferalLink = $"https://tt-swap.net/register?sponsor=TTS{user.Sponsor}",
                Sponsor = $"TTS{user.Sponsor}",
                IsSystem = user.IsSystem,
                ByCreated = user.ByCreated,
                ByModified = user.ByModified,
                DateModified = user.DateModified,
                UserName = user.UserName,
                Email = user.Email,
                Status = user.Status,
                DateCreated = user.DateCreated,
                Roles = roles.ToList()
            };

            if (!user.TwoFactorEnabled)
            {
                userVm.AuthenticatorCode = await _authenticationService.GetAuthenticatorKey(user);
            }

            return userVm;
        }

        public async Task<bool> AddAsync(AppUserViewModel userVm)
        {
            var user = new AppUser()
            {
                UserName = userVm.UserName,
                Email = userVm.Email,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                LockBalance = 0,
                StakingBalance = 0,
                StakingInterest = 0,
                IsSystem = true
            };

            var result = await _userManager.CreateAsync(user, userVm.Password);
            if (result.Succeeded && userVm.Roles.Count > 0)
            {
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                if (appUser != null)
                {
                    await _userManager.AddToRolesAsync(appUser, userVm.Roles.ToArray());
                }
            }

            return result.Succeeded;
        }


        public async Task UpdateAsync(AppUserViewModel userVm)
        {
            var user = await _userManager.FindByIdAsync(userVm.Id.ToString());

            //Remove current roles in db
            var currentRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, userVm.Roles.Except(currentRoles).ToArray());
            if (result.Succeeded)
            {
                string[] needRemoveRoles = currentRoles.Except(userVm.Roles).ToArray();
                await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);

                user.Status = userVm.Status;
                user.Email = userVm.Email;
                user.DateModified = DateTime.Now;

                await _userManager.UpdateAsync(user);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        #endregion
    }
}
