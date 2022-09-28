﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using avarice_backend.Services.Interfaces;
using avarice_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace avarice_backend.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [ApiController]
  [Route("api/account")]
  public class AccountController : ControllerBase
  {
    private readonly avariceContext _context;
    private readonly IAccountService _accountService;

    public AccountController(avariceContext context, IAccountService accountService)
    {
      _context = context;
      _accountService = accountService;
    }

    [HttpGet]
    public async Task<IEnumerable<AccountModel>> GetUserAccounts()
    {
      var data = await _accountService.GetLatestValues(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }

    [HttpGet("expense-income/{id}")]
    public async Task<AccountExpenseAndIncomeModel> GetExpenseAndIncomeInTimePeriod(int id)
    {
      var data = await _accountService.GetExpensesAndIncomeInTimePeriod(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, id);
      return data;
    }

    [HttpGet("history/{id}")]
    public async Task<IEnumerable<AccountHistoryModel>> GetAccountHistory(int id)
    {
      var data = await _accountService.GetAccountHistory(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, id, Utils.TimePeriodEnum.ThirtyDays);
      return data;
    }
  }
}
