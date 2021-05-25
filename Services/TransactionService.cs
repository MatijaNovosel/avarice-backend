using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
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
      _transactionRepository = _transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
      _transactionTagRepository = _transactionTagRepository ?? throw new ArgumentNullException(nameof(transactionTagRepository));
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
    }

    public async Task<int> AddTransaction(TransactionModel payload)
    {
      var mappedTransaction = ObjectMapper.Mapper.Map<Transaction>(payload);
      await _transactionRepository.AddAsync(mappedTransaction);

      payload.TagIds.ForEach(async TagId =>
      {
        await _transactionTagRepository.AddAsync(new Transactiontag()
        {
          TagId = TagId,
          TransactionId = mappedTransaction.Id
        });
      });

      var Accounts = await _accountRepository.GetAsync(account => account.UserId == payload.UserId);

      foreach (var account in Accounts)
      {
        double currentAccountAmount = await _accountRepository.GetCurrentAmount(account.Id);
        await _historyRepository.AddAsync(new History()
        {
          AccountId = account.Id,
          CreatedAt = payload.CreatedAt,
          UserId = payload.UserId,
          Amount = payload.AccountId == account.Id ? (payload.Expense ? currentAccountAmount - payload.Amount : currentAccountAmount + payload.Amount) : currentAccountAmount
        });
      }

      return mappedTransaction.Id;
    }
  }
}