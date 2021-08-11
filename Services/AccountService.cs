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

    public AccountService(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<IEnumerable<Account>> GetLatestValues(string userId)
    {
      var accounts = await _accountRepository.GetAsync(account => account.UserId == userId);
      return accounts;
    }
  }
}