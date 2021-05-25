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
  public class HistoryRepository : Repository<History>, IHistoryRepository
  {
    public HistoryRepository(finappContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<DateTime>> GetGroupedByCreatedAt(string userId, DateTime from, DateTime to)
    {
      var res = await _dbContext.Histories
        .Where(history => history.CreatedAt >= from && history.CreatedAt <= to && history.UserId == userId)
        .GroupBy(history => history.CreatedAt)
        .Select(createdAt => createdAt.Key)
        .ToListAsync();
      return res;
    }
  }
}