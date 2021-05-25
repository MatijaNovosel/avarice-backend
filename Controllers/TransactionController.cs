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
    public async Task<int> Add(TransactionModel payload)
    {
      var data = await _transactionService.AddTransaction(payload);
      return data;
    }
  }
}
