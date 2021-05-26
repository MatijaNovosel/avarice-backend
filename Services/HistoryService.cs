using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;

namespace fin_app_backend.Services
{
  public class HistoryService : IHistoryService
  {
    private readonly IHistoryRepository _historyRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUserService _userService;

    public HistoryService(IHistoryRepository historyRepository, IUserService userService, ITransactionRepository transactionRepository)
    {
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
      _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
      _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IEnumerable<HistoryTotalModel>> GetTotal(string userId, DateTime from, DateTime to)
    {
      var historyGrouped = await _historyRepository.GetGroupedByCreatedAt(userId, from, to);
      List<HistoryTotalModel> res = new List<HistoryTotalModel>();

      foreach (var createdAt in historyGrouped)
      {
        double total = 0;
        var history = await _historyRepository.GetAsync(history => history.UserId == userId && history.CreatedAt == createdAt);

        foreach (var h in history)
        {
          total += h.Amount;
        }

        res.Add(new HistoryTotalModel()
        {
          Amount = total,
          CreatedAt = createdAt
        });
      }

      return res;
    }

    public async Task<RecentDepositsAndWithdrawalsModel> GetRecentDepositsAndWithdrawals(string userId)
    {
      DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);

      var withdrawals = await _transactionRepository.GetAsync(t => t.Expense == true && t.Transfer == 0 && t.CreatedAt >= thirtyDaysAgo && t.UserId == userId);
      var deposits = await _transactionRepository.GetAsync(t => t.Expense == false && t.Transfer == 0 && t.CreatedAt >= thirtyDaysAgo && t.UserId == userId);

      double withdrawalSum = 0;
      double depositSum = 0;

      foreach (var withdrawal in withdrawals)
      {
        withdrawalSum += (double)withdrawal.Amount;
      }

      foreach (var deposit in deposits)
      {
        depositSum += (double)deposit.Amount;
      }

      return new RecentDepositsAndWithdrawalsModel()
      {
        Deposits = withdrawalSum,
        Withdrawals = depositSum
      };
    }

    public async Task<IEnumerable<DailyChangeModel>> GetDailyChanges(string userId)
    {
      var historyGrouped = await _historyRepository.GetGroupedByCreatedAt(userId);
      List<DailyChangeModel> dailyChanges = new List<DailyChangeModel>();

      foreach (var date in historyGrouped)
      {
        var deposits = await GetDailyChangeForDate(date, false);
        var withdrawals = await GetDailyChangeForDate(date, true);
        dailyChanges.Add(new DailyChangeModel()
        {
          CreatedAt = date,
          Deposits = deposits,
          Withdrawals = withdrawals
        });
      }

      return dailyChanges;
    }

    public async Task<double> GetDailyChangeForDate(DateTime date, bool expense)
    {
      double amount = 0;

      var transactions = await _transactionRepository.GetAsync(t => t.CreatedAt == date && t.Expense == expense && t.Transfer == 0);

      foreach (var transaction in transactions)
      {
        amount += (double)transaction.Amount;
      }

      return amount;
    }
  }
}