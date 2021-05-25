using System.Threading.Tasks;
using fin_app_backend.Models;
using System;
using System.Collections.Generic;

namespace fin_app_backend.Services.Interfaces
{
  public interface IHistoryService
  {
    Task<IEnumerable<HistoryTotalModel>> GetTotal(int UserId, DateTime from, DateTime to);
  }
}