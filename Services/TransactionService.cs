using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using avarice_backend.Services.Interfaces;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Constants;
using avarice_backend.Models;
using avarice_backend.Mapper;
using avarice_backend.Utils;
using avarice_backend.Extensions;
using System.Linq;

namespace avarice_backend.Services
{
  public class TransactionService : ITransactionService
  {
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITemplateRepository _templateRepository;

    public TransactionService(
      ITransactionRepository transactionRepository,
      IAccountRepository accountRepository,
      ITemplateRepository templateRepository
    )
    {
      _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
      _templateRepository = templateRepository ?? throw new ArgumentNullException(nameof(templateRepository));
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task AddTransaction(AddTransactionDto payload, string userId)
    {
      var account = await _accountRepository.GetByIdAsync(payload.AccountId);
      account.Balance = account.Balance + payload.Amount;
      await _accountRepository.UpdateAsync(account);

      await _transactionRepository.AddAsync(new Transaction()
      {
        AccountId = account.Id,
        Amount = payload.Amount,
        TransactionType = payload.TransactionType,
        CategoryId = payload.CategoryId,
        Description = payload.Description,
        UserId = userId,
        CreatedAt = payload.CreatedAt ?? DateTime.Now
      });
    }

    public async Task AddTransfer(AddTransferDto transfer, string userId)
    {
      var accountFrom = await _accountRepository.GetByIdAsync(transfer.AccountFromId);
      var accountTo = await _accountRepository.GetByIdAsync(transfer.AccountToId);

      accountFrom.Balance = accountFrom.Balance - transfer.Amount;
      accountTo.Balance = accountTo.Balance + transfer.Amount;

      await _accountRepository.UpdateAsync(accountFrom);
      await _accountRepository.UpdateAsync(accountTo);

      await _transactionRepository.AddAsync(new Transaction()
      {
        AccountId = accountFrom.Id,
        Amount = transfer.Amount,
        TransactionType = TransactionType.Transfer,
        CategoryId = (long)SystemCategoryEnum.Transfer,
        Description = $"Transfer ({accountFrom.Name} => {accountTo.Name})",
        TransferAccountId = accountTo.Id,
        UserId = userId,
        CreatedAt = transfer.CreatedAt ?? DateTime.Now
      });
    }

    public async Task<IEnumerable<TransactionModel>> GetAll(
      string userId,
      int? skip,
      int? take,
      string description,
      string transactionType,
      int? categoryType
    )
    {
      var transactions = await _transactionRepository.GetTransactionsPaginated(
        userId,
        skip,
        take,
        description,
        transactionType,
        categoryType
      );
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<TransactionModel>>(transactions);
      return mapped;
    }

    public async Task<long> GetCount(
      string userId,
      string description,
      string transactionType,
      int? categoryType
    )
    {
      var count = await _transactionRepository.GetTransactionsCount(
        userId,
        description,
        transactionType,
        categoryType
      );
      return count;
    }

    public async Task DeleteTransaction(string userId, long tId)
    {
      var transaction = await _transactionRepository.GetByIdAsync(tId);
      var account = await _accountRepository.GetByIdAsync((long)transaction.AccountId);

      if (transaction.TransactionType == TransactionType.Transfer)
      {
        var accountTo = await _accountRepository.GetByIdAsync((long)transaction.TransferAccountId);
        accountTo.Balance = (double)(accountTo.Balance - transaction.Amount);
        await _accountRepository.UpdateAsync(accountTo);
      }
      else
      {
        account.Balance = (double)(transaction.TransactionType == TransactionType.Expense ?
          account.Balance + transaction.Amount :
          account.Balance - transaction.Amount);
      }

      await _accountRepository.UpdateAsync(account);
      await _transactionRepository.DeleteAsync(transaction);
    }

    public async Task<IEnumerable<TransactionActivityHeatmapModel>> GetTransactionActivityHeatmap(string userId)
    {
      var res = new List<TransactionActivityHeatmapModel>();

      DateTime startOfWeek = DateTime.Now.AddWeeks(-4).StartOfWeek(DayOfWeek.Monday);
      int dayDifference = DateTime.Now.DifferenceInDays(startOfWeek);

      var transactions = await _transactionRepository.GetAsync(t =>
        t.UserId == userId &&
        t.CreatedAt >= startOfWeek &&
        t.CreatedAt <= DateTime.Now
      );

      for (int n = 0; n < dayDifference; n++)
      {
        var date = startOfWeek.AddDays(n);
        var transactionAtDate = transactions.Where(t => t.CreatedAt == date);

        res.Add(new TransactionActivityHeatmapModel
        {
          Date = date,
          Value = transactionAtDate.Count(),
          Week = date.GetIso8601WeekOfYear(),
          WeekDay = date.ToString("ddd").Substring(0, 2)
        });
      }

      return res;
    }
  }
}