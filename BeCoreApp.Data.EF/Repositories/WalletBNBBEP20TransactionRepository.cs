using BeCoreApp.Data.Entities;
using BeCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeCoreApp.Data.EF.Repositories
{
    public class WalletBNBBEP20TransactionRepository : EFRepository<WalletBNBBEP20Transaction, int>, IWalletBNBBEP20TransactionRepository
    {
        public WalletBNBBEP20TransactionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
