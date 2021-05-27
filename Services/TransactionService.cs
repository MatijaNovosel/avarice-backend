using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Constants;
using fin_app_backend.Models;
using fin_app_backend.Mapper;

namespace fin_app_backend.Services
{
  public class TransactionService : ITransactionService
  {
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionTagRepository _transactionTagRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IHistoryRepository _historyRepository;

    public TransactionService(ITransactionRepository transactionRepository, ITransactionTagRepository transactionTagRepository, IAccountRepository accountRepository, IHistoryRepository historyRepository)
    {
      _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
      _transactionTagRepository = transactionTagRepository ?? throw new ArgumentNullException(nameof(transactionTagRepository));
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
    }

    public async Task AddTransaction(AddTransactionDto payload)
    {
      var mappedTransaction = ObjectMapper.Mapper.Map<Transaction>(payload);
      await _transactionRepository.AddAsync(mappedTransaction);

      foreach (var TagId in payload.TagIds)
      {
        await _transactionTagRepository.AddAsync(new Transactiontag()
        {
          TagId = TagId,
          TransactionId = mappedTransaction.Id
        });
      };

      var Accounts = await _accountRepository.GetAsync(account => account.UserId == payload.UserId);

      foreach (var account in Accounts)
      {
        double currentAccountAmount = await _accountRepository.GetCurrentAmount(account.Id);
        await _historyRepository.AddAsync(new History()
        {
          AccountId = account.Id,
          CreatedAt = payload.CreatedAt,
          UserId = payload.UserId,
          Amount = payload.AccountId == account.Id ? ((bool)payload.Expense == true ? (currentAccountAmount - payload.Amount) : (currentAccountAmount + payload.Amount)) : currentAccountAmount
        });
      }
    }
    public async Task AddTransfer(AddTransferDto transfer)
    {
      DateTime now = new DateTime();

      var transferFrom = new Transaction()
      {
        Amount = transfer.Amount,
        Description = "Transfer",
        Expense = true,
        Transfer = 1,
        AccountId = transfer.AccountFromId,
        UserId = transfer.UserId,
        CreatedAt = now
      };

      var transferTo = new Transaction()
      {
        Amount = transfer.Amount,
        Description = "Transfer",
        Expense = false,
        Transfer = 1,
        AccountId = transfer.AccountToId,
        UserId = transfer.UserId,
        CreatedAt = now
      };

      await _transactionRepository.AddAsync(transferFrom);
      await _transactionRepository.AddAsync(transferTo);

      await _transactionTagRepository.AddAsync(new Transactiontag() { TagId = (int)SystemTags.Transfer, TransactionId = transferFrom.Id });
      await _transactionTagRepository.AddAsync(new Transactiontag() { TagId = (int)SystemTags.Transfer, TransactionId = transferTo.Id });

      var Accounts = await _accountRepository.GetAsync(account => account.UserId == transfer.UserId);

      foreach (var account in Accounts)
      {
        double currentAccountAmount = await _accountRepository.GetCurrentAmount(account.Id);
        await _historyRepository.AddAsync(new History()
        {
          AccountId = account.Id,
          CreatedAt = now,
          UserId = transfer.UserId,
          Amount = account.Id == transfer.AccountFromId ?
            (currentAccountAmount - transfer.Amount) :
            (account.Id == transfer.AccountToId ? (currentAccountAmount + transfer.Amount) : currentAccountAmount)
        });
      }
    }
  }
}