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
    private readonly ITagRepository _tagRepository;
    private readonly ITransactionTagRepository _transactionTagRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IHistoryRepository _historyRepository;

    public TransactionService(
      ITransactionRepository transactionRepository,
      ITransactionTagRepository transactionTagRepository,
      IAccountRepository accountRepository,
      IHistoryRepository historyRepository,
      ITagRepository tagRepository
    )
    {
      _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
      _transactionTagRepository = transactionTagRepository ?? throw new ArgumentNullException(nameof(transactionTagRepository));
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
      _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
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
      var transferFrom = new Transaction()
      {
        Amount = transfer.Amount,
        Description = "Transfer",
        Expense = true,
        Transfer = 1,
        AccountId = transfer.AccountFromId,
        UserId = transfer.UserId,
        CreatedAt = transfer.CreatedAt
      };

      var transferTo = new Transaction()
      {
        Amount = transfer.Amount,
        Description = "Transfer",
        Expense = false,
        Transfer = 1,
        AccountId = transfer.AccountToId,
        UserId = transfer.UserId,
        CreatedAt = transfer.CreatedAt
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
          CreatedAt = transfer.CreatedAt,
          UserId = transfer.UserId,
          Amount = account.Id == transfer.AccountFromId ?
            (currentAccountAmount - transfer.Amount) :
            (account.Id == transfer.AccountToId ? (currentAccountAmount + transfer.Amount) : currentAccountAmount)
        });
      }
    }

    public async Task<IEnumerable<TransactionModel>> GetAll(string userId, int? skip, int? take)
    {
      var res = new List<TransactionModel>();
      var transactions = await _transactionRepository.GetTransactionsPaginated(userId, skip, take);

      foreach (var transaction in transactions)
      {
        var tagIds = transaction.Transactiontags.Select(y => y.TagId);
        var tags = await _tagRepository.GetAsync(y => tagIds.Contains(y.Id));
        var mappedTags = ObjectMapper.Mapper.Map<IEnumerable<TagModel>>(tags);

        res.Add(new TransactionModel()
        {
          Id = transaction.Id,
          Amount = transaction.Amount,
          CreatedAt = transaction.CreatedAt,
          Description = transaction.Description,
          Expense = transaction.Expense,
          Transfer = Convert.ToBoolean(transaction.Transfer),
          UserId = userId,
          Tags = mappedTags.ToList(),
          Account = new AccountTransactionModel()
          {
            Description = transaction.Account.Description,
            Id = transaction.Account.Id
          }
        });
      }

      return res;
    }

    public async Task<long> GetCount(string userId) 
    {
      var transactions = await _transactionRepository.GetAllAsync();
      return transactions.Count;
    }
  }
}