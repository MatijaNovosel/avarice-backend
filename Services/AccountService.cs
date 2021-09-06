using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using fin_app_backend.Utils;
using System.Linq;
using System.Globalization;

namespace fin_app_backend.Services
{
  public class AccountService : IAccountService
  {
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
      _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
    }

    public async Task<IEnumerable<AccountModel>> GetLatestValues(string userId)
    {
      var accounts = await _accountRepository.GetAsync(account => account.UserId == userId);
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);
      return mapped;
    }

    public async Task<AccountExpenseAndIncomeModel> GetExpensesAndIncomeInTimePeriod(string userId, long accountId)
    {
      var toRange = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
      var fromRange = long.Parse(DateTime.Now.AddDays(-30).ToString("yyyyMMddHHmmss"));

      var transactions = await _transactionRepository.GetAsync(t =>
        t.UserId == userId &&
        t.AccountId == accountId &&
        t.Id >= fromRange &&
        t.Id <= toRange
      );

      return new AccountExpenseAndIncomeModel
      {
        Expense = (double)transactions
          .Where(x => x.TransactionType == TransactionType.Expense)
          .Sum(x => x.Amount),
        Income = (double)transactions
          .Where(x => x.TransactionType == TransactionType.Income)
          .Sum(x => x.Amount)
      };
    }

    public async Task<IEnumerable<AccountHistoryModel>> GetAccountHistory(string userId, long accountId, TimePeriodEnum timePeriod)
    {
      var res = new List<AccountHistoryModel>();

      var accountBalance = (await _accountRepository.GetByIdAsync(accountId)).Balance;

      var toRange = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
      var fromRange = long.Parse(DateTime.Now.AddDays(-30).ToString("yyyyMMddHHmmss"));

      var transactions = await _transactionRepository.GetAsync(t =>
        t.UserId == userId &&
        t.AccountId == accountId &&
        t.Id >= fromRange &&
        t.Id <= toRange
      );

      if (transactions.Count != 0)
      {
        var currentAmount = accountBalance;

        for (int i = 0; i <= 30; i++)
        {
          var id = long.Parse(DateTime.Now.AddDays(i * -1).ToString("yyyyMMddHHmmss"));
          var transactionAtDate = transactions.Where(x => long.Parse(
            x.Id.ToString().Substring(0, 8)) == long.Parse(id.ToString().Substring(0, 8))
          ).ToList();

          if (transactionAtDate.Count != 0)
          {
            foreach (var t in transactionAtDate)
            {
              if (t.TransactionType == TransactionType.Expense)
              {
                currentAmount += (double)t.Amount * -1;
              }
              else if (t.TransactionType == TransactionType.Income)
              {
                currentAmount -= (double)t.Amount;
              }
            }
          }

          res.Add(new AccountHistoryModel
          {
            Amount = currentAmount,
            Date = DateTime.Now.AddDays(i * -1)
          });
        }
      }
      else
      {
        for (int i = 0; i <= 30; i++) res.Add(new AccountHistoryModel
        {
          Amount = accountBalance,
          Date = DateTime.Now.AddDays(i * -1)
        });
      }

      return res;
    }
  }
}