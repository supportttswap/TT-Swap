using BeCoreApp.Data.Entities;
using BeCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BeCoreApp.Data.EF.Repositories
{
    public class MetamaskTransactionRepository : EFRepository<MetamaskTransaction, Guid>, IMetamaskTransactionRepository
    {
        public MetamaskTransactionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
