using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using System.Linq;

namespace fin_app_backend.Services
{
  public class AccountService : IAccountService
  {
    private readonly IAccountRepository _accountRepository;
    private readonly IHistoryRepository _historyRepository;

    public AccountService(IAccountRepository accountRepository, IHistoryRepository historyRepository)
    {
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
    }

    public async Task<IEnumerable<AccountLatestValueModel>> GetLatestValues(string userId)
    {
      List<AccountLatestValueModel> data = new List<AccountLatestValueModel>();
      var accounts = await _accountRepository.GetAsync(account => account.UserId == userId);

      foreach (var account in accounts)
      {
        var historyRecord = await _historyRepository.GetAsync(x => x.AccountId == account.Id);
        data.Add(new AccountLatestValueModel()
        {
          Amount = historyRecord.Last().Amount,
          Currency = account.Currency,
          Description = account.Description,
          Icon = account.Icon,
          Id = account.Id
        });
      }

      return data;
    }

    public async Task<IEnumerable<AccountModel>> GetUserAccounts(string userId)
    {
      var accounts = await _accountRepository.GetAsync(account => account.UserId == userId);
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);
      return mapped;
    }
  }
}