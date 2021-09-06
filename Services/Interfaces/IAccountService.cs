using fin_app_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Utils;

namespace fin_app_backend.Services.Interfaces
{
  public interface IAccountService
  {
    Task<IEnumerable<AccountModel>> GetLatestValues(string userId);
    Task<IEnumerable<AccountHistoryModel>> GetAccountHistory(string userId, long accountId, TimePeriodEnum timePeriod);
    Task<AccountExpenseAndIncomeModel> GetExpensesAndIncomeInTimePeriod(string userId, long accountId);
  }
}