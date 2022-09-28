using System.Threading.Tasks;
using avarice_backend.Models;
using System;
using System.Collections.Generic;

namespace avarice_backend.Services.Interfaces
{
  public interface IHistoryService
  {
    Task<IEnumerable<HistoryTotalModel>> GetTotal(string userId, DateTime from, DateTime to);
    Task<IEnumerable<HistoryTotalModel>> GetHistoryForAccount(string userId, long accountId);
    Task<IEnumerable<HistoryTotalModel>> GetHistoryForAccount(string userId, long accountId, DateTime from, DateTime to);
    Task<RecentDepositsAndWithdrawalsModel> GetRecentDepositsAndWithdrawals(string userId);
    Task<IEnumerable<DailyChangeModel>> GetDailyChanges(string userId);
    Task<double> GetDailyChangeForDate(DateTime date, bool expense);
    Task<DateTime> GetLatestDate(string userId);
    Task<IEnumerable<TagPercentageModel>> GetTagPercentages(string userId);
    Task<IEnumerable<SpendingByTagModel>> SpendingByTag(string userId);
  }
}