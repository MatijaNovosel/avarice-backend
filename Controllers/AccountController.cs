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
  [Route("api/account")]
  public class AccountController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly IAccountService _accountService;

    public AccountController(finappContext context, IAccountService accountService)
    {
      _context = context;
      _accountService = accountService;
    }

    [Authorize(Policy = "UserMustBeAuthor")]
    [HttpGet]
    public async Task<IEnumerable<AccountLatestValueModel>> LatestValues(string userId)
    {
      var data = await _accountService.GetLatestValues(userId);
      return data;
    }
  }
}
