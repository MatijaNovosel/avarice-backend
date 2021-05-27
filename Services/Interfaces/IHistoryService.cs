using System.Threading.Tasks;
using fin_app_backend.Models;
using System;
using System.Collections.Generic;

namespace fin_app_backend.Services.Interfaces
{
  public interface IHistoryService
  {
    Task<IEnumerable<HistoryTotalModel>> GetTotal(string userId, DateTime from, DateTime to);
    Task<IEnumerable<HistoryTotalModel>> GetHistoryForAccount(string userId, int accountId);
    Task<IEnumerable<HistoryTotalModel>> GetHistoryForAccount(string userId, int accountId, DateTime from, DateTime to);
    Task<RecentDepositsAndWithdrawalsModel> GetRecentDepositsAndWithdrawals(string userId);
    Task<IEnumerable<DailyChangeModel>> GetDailyChanges(string userId);
    Task<double> GetDailyChangeForDate(DateTime date, bool expense);
    Task<DateTime> GetLatestDate(string userId);
  }
}