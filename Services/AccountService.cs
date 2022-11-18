using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using avarice_backend.Services.Interfaces;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Models;
using avarice_backend.Mapper;
using avarice_backend.Utils;
using System.Linq;
using System.Globalization;

namespace avarice_backend.Services
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

    private int CalculateDaysFromTimePeriod(TimePeriodEnum timePeriod)
    {
      switch (timePeriod)
      {
        case TimePeriodEnum.SevenDays: return 7;
        case TimePeriodEnum.ThirtyDays: return 30;
        case TimePeriodEnum.TwelveWeeks: return 84;
        case TimePeriodEnum.SixMonths: return 180;
        case TimePeriodEnum.OneYear: return 365;
        default: return -30;
      }
    }

    public async Task<IEnumerable<AccountModel>> GetLatestValues(string userId)
    {
      var accounts = await _accountRepository.GetAsync(account => account.UserId == userId);
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);

      foreach (AccountModel account in mapped)
      {
        var transactions = await _transactionRepository.GetAsync(t => t.AccountId == account.Id);
        var sum = transactions.Select(t => t.Amount).Sum();
        account.Balance += sum;
      }

      return mapped;
    }

    public async Task<AccountExpenseAndIncomeModel> GetExpensesAndIncomeInTimePeriod(string userId, long accountId)
    {
      var toRange = DateTime.Now;
      var fromRange = DateTime.Now.AddDays(-CalculateDaysFromTimePeriod(TimePeriodEnum.ThirtyDays));

      var transactions = await _transactionRepository.GetAsync(t =>
        t.Account.UserId == userId &&
        t.AccountId == accountId &&
        t.CreatedAt >= fromRange &&
        t.CreatedAt <= toRange
      );

      return new AccountExpenseAndIncomeModel
      {
        Expense = (double)transactions
          .Where(x => x.Amount < 0)
          .Sum(x => x.Amount),
        Income = (double)transactions
          .Where(x => x.Amount > 0)
          .Sum(x => x.Amount)
      };
    }

    public async Task<IEnumerable<AccountHistoryModel>> GetAccountHistory(string userId, long accountId, TimePeriodEnum timePeriod)
    {
      var res = new List<AccountHistoryModel>();
      var accountBalance = (await _accountRepository.GetByIdAsync(accountId)).InitialBalance;
      var accountTransactions = await _transactionRepository.GetAsync(t => t.AccountId == accountId);
      var sum = accountTransactions.Select(t => t.Amount).Sum();

      accountBalance += sum;

      int days = CalculateDaysFromTimePeriod(timePeriod);
      var toRange = DateTime.Now.Date;
      var fromRange = DateTime.Now.AddDays(-days).Date;

      var transactions = accountTransactions.Where(t =>
        t.CreatedAt.Date >= fromRange &&
        t.CreatedAt.Date <= toRange
      ).ToList();

      if (transactions.Count != 0)
      {
        var currentAmount = accountBalance;

        res.Add(new AccountHistoryModel
        {
          Amount = currentAmount,
          Date = DateTime.Now
        });

        var transactionNow = transactions.Where(x => x.CreatedAt == DateTime.Now).ToList();

        if (transactionNow.Count != 0)
        {
          foreach (var t in transactionNow)
          {
            if (t.Amount < 0)
            {
              currentAmount += (double)t.Amount * -1;
            }
            else
            {
              currentAmount -= (double)t.Amount;
            }
          }
        }

        for (int i = 1; i <= days; i++)
        {
          var date = DateTime.Now.AddDays(i * -1).Date;
          var transactionAtDate = transactions.Where(t => t.CreatedAt.Date == date).ToList();

          if (transactionAtDate.Count != 0)
          {
            foreach (var t in transactionAtDate)
            {
              if (t.Amount < 0)
              {
                currentAmount += (double)t.Amount * -1;
              }
              else
              {
                currentAmount -= (double)t.Amount;
              }
            }
          }

          res.Add(new AccountHistoryModel
          {
            Amount = currentAmount,
            Date = date
          });
        }
      }
      else
      {
        for (int i = 0; i <= days; i++) res.Add(new AccountHistoryModel
        {
          Amount = accountBalance,
          Date = DateTime.Now.AddDays(i * -1)
        });
      }

      return res;
    }

    public async Task Create(string userId, CreateAccountModel payload)
    {
      await _accountRepository.AddAsync(new Account()
      {
        Currency = "HRK",
        InitialBalance = payload.InitialBalance,
        Name = payload.Name,
        UserId = userId
      });
    }
  }
}