using BeCoreApp.Data.Entities;
using BeCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeCoreApp.Data.EF.Repositories
{
    public class LuckyRoundHistoryRepository : EFRepository<LuckyRoundHistory, int>, ILuckyRoundHistoryRepository
    {
        public LuckyRoundHistoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
