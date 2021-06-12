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
using System.Security.Claims;

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

    [HttpGet("total")]
    public async Task<IEnumerable<HistoryTotalModel>> Total(DateTime from, DateTime to)
    {
      var data = await _historyService.GetTotal(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, from, to);
      return data;
    }

    [HttpGet("recent-deposits-and-withdrawals")]
    public async Task<RecentDepositsAndWithdrawalsModel> RecentDepositsAndWithdrawals()
    {
      var data = await _historyService.GetRecentDepositsAndWithdrawals(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }

    [HttpGet("daily-changes")]
    public async Task<IEnumerable<DailyChangeModel>> DailyChanges()
    {
      var data = await _historyService.GetDailyChanges(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }

    [HttpGet("latest-date")]
    public async Task<DateTime> LatestDate()
    {
      var data = await _historyService.GetLatestDate(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }

    [HttpGet("account-total/{accountId}")]
    public async Task<IEnumerable<HistoryTotalModel>> AccountHistoryTotal([FromRoute] int accountId)
    {
      var data = await _historyService.GetHistoryForAccount(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, accountId);
      return data;
    }

    [HttpGet("account/{accountId}")]
    public async Task<IEnumerable<HistoryTotalModel>> AccountHistory([FromRoute] int accountId, DateTime from, DateTime to)
    {
      var data = await _historyService.GetHistoryForAccount(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, accountId, from, to);
      return data;
    }

    [HttpGet("tag-percentages")]
    public async Task<IEnumerable<TagPercentageModel>> TagPercentages()
    {
      var data = await _historyService.GetTagPercentages(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }
  }
}
