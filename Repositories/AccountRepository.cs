using fin_app_backend.Entities;
using fin_app_backend.Repositories;
using fin_app_backend.Specifications;
using fin_app_backend.Repositories.Base;
using fin_app_backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fin_app_backend.Repositories
{
  public class AccountRepository : Repository<Account>, IAccountRepository
  {
    public AccountRepository(finappContext dbContext) : base(dbContext)
    {
    }

    public async Task<double> GetCurrentAmount(int accountId)
    {
      var latestHistoryEntry = await _dbContext.Histories.Where(historyEntry => historyEntry.AccountId == accountId).OrderBy(x => x.CreatedAt).LastOrDefaultAsync();
      return latestHistoryEntry.Amount;
    }
  }
}