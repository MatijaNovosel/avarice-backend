using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using fin_app_backend.Utils;
using System.Linq;

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

    public async Task<AccountExpenseAndIncomeModel> GetExpensesAndIncomeInTimePeriod(string userId, int accountId)
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
  }
}