using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Constants;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using System.Linq;

namespace fin_app_backend.Services
{
  public class TransactionService : ITransactionService
  {
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;

    public TransactionService(
      ITransactionRepository transactionRepository,
      IAccountRepository accountRepository
    )
    {
      _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task AddTransaction(AddTransactionDto payload, string userId)
    {
      var account = await _accountRepository.GetByIdAsync(payload.AccountId);

      account.Balance = payload.TransactionType == "EXP" ? account.Balance - payload.Amount : account.Balance + payload.Amount;

      /*

        Transaction Id -> 2021-08-12-14-56-45
        YEAR - MONTH - DAY - HOURS - MINUTES - SECONDS

      */

      await _transactionRepository.AddAsync(new Transaction()
      {
        AccountId = account.Id,
        Amount = payload.Amount,
        TransactionType = payload.TransactionType,
        CategoryId = payload.CategoryId,
        Description = payload.Description,
        UserId = userId,
        Id = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"))
      });
    }

    public async Task AddTransfer(AddTransferDto transfer, string userId)
    {
      //
    }

    public async Task<IEnumerable<TransactionModel>> GetAll(string userId, int? skip, int? take)
    {
      return new List<TransactionModel>();
    }

    public async Task<long> GetCount(string userId)
    {
      var transactions = await _transactionRepository.GetAllAsync();
      return transactions.Count;
    }
  }
}