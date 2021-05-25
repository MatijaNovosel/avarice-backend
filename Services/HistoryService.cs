using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;

namespace fin_app_backend.Services
{
  public class HistoryService : IHistoryService
  {
    private readonly IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
      _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
    }

    public async Task<IEnumerable<HistoryTotalModel>> GetTotal(int userId, DateTime from, DateTime to)
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
  }
}