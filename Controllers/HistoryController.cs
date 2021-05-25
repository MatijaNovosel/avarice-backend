using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Models;

namespace fin_app_backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
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
    public async Task<IEnumerable<HistoryTotalModel>> Total(string userId, DateTime from, DateTime to)
    {
      var data = await _historyService.GetTotal(userId, from, to);
      return data;
    }
  }
}
