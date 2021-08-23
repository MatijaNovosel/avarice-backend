using fin_app_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fin_app_backend.Services.Interfaces
{
  public interface IAccountService
  {
    Task<IEnumerable<AccountModel>> GetLatestValues(string userId);
    Task<AccountExpenseAndIncomeModel> GetExpensesAndIncomeInTimePeriod(string userId, int accountId);
  }
}