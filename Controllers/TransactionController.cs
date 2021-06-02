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
  [Route("api/transaction")]
  public class TransactionController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly ITransactionService _transactionService;

    public TransactionController(finappContext context, ITransactionService transactionService)
    {
      _context = context;
      _transactionService = transactionService;
    }

    [HttpPost]
    public async Task Add(AddTransactionDto payload)
    {
      await _transactionService.AddTransaction(payload);
    }

    [HttpPost("transfer")]
    public async Task Transfer(AddTransferDto payload)
    {
      await _transactionService.AddTransfer(payload);
    }

    [HttpGet]
    public async Task<IEnumerable<TransactionModel>> Get(string userId, int skip, int take)
    {
      var data = await _transactionService.GetAll(userId, skip, take);
      return data;
    }
  }
}
