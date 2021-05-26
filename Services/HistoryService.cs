using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using Microsoft.AspNetCore.Identity;

namespace fin_app_backend.Services
{
  public class HistoryService : IHistoryService
  {
    private readonly IHistoryRepository _historyRepository;
    private readonly IUserService _userService;

    public HistoryService(IHistoryRepository historyRepository, IUserService userService)
    {
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
      _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IEnumerable<HistoryTotalModel>> GetTotal(string userId, DateTime from, DateTime to)
    {
      var historyGrouped = await _historyRepository.GetGroupedByCreatedAt(userId, from, to);
      List<HistoryTotalModel> res = new List<HistoryTotalModel>();

      foreach (var createdAt in historyGrouped)
      {
        double total = 0;
        var history = await _historyRepository.GetAsync(history => history.UserId == userId && history.CreatedAt == createdAt);

        foreach (var h in history)
        {
          total += h.Amount;
        }

        res.Add(new HistoryTotalModel()
        {
          Amount = total,
          CreatedAt = createdAt
        });
      }

      return res;
    }

    public async Task<RecentDepositsAndWithdrawalsModel> GetRecentDepositsAndWithdrawals(string userId)
    {
      return new RecentDepositsAndWithdrawalsModel()
      {
        Deposits = 100,
        Withdrawals = 200
      };
    }
  }
}