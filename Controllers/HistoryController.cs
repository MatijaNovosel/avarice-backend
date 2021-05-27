using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace fin_app_backend.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [ApiController]
  [Route("api/history")]
  public class HistoryController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly IHistoryService _historyService;

    public HistoryController(finappContext context, IHistoryService historyService)
    {
      _context = context;
      _historyService = historyService;
    }

    [Authorize(Policy = "UserMustBeAuthor")]
    [HttpGet("total")]
    public async Task<IEnumerable<HistoryTotalModel>> Total(string userId, DateTime from, DateTime to)
    {
      var data = await _historyService.GetTotal(userId, from, to);
      return data;
    }

    [Authorize(Policy = "UserMustBeAuthor")]
    [HttpGet("recent-deposits-and-withdrawals")]
    public async Task<RecentDepositsAndWithdrawalsModel> RecentDepositsAndWithdrawals(string userId)
    {
      var data = await _historyService.GetRecentDepositsAndWithdrawals(userId);
      return data;
    }

    [Authorize(Policy = "UserMustBeAuthor")]
    [HttpGet("daily-changes")]
    public async Task<IEnumerable<DailyChangeModel>> DailyChanges(string userId)
    {
      var data = await _historyService.GetDailyChanges(userId);
      return data;
    }

    [Authorize(Policy = "UserMustBeAuthor")]
    [HttpGet("latest-date")]
    public async Task<DateTime> LatestDate(string userId)
    {
      var data = await _historyService.GetLatestDate(userId);
      return data;
    }
  }
}
