using System;
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
  [Route("api/transaction")]
  public class TransactionController : ControllerBase
  {
    private readonly AvariceContext _context;
    private readonly ITransactionService _transactionService;

    public TransactionController(AvariceContext context, ITransactionService transactionService)
    {
      _context = context;
      _transactionService = transactionService;
    }

    [HttpPost]
    public async Task Add(AddTransactionDto payload)
    {
      await _transactionService.AddTransaction(payload, ((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
    }

    [HttpPost("transfer")]
    public async Task Transfer(AddTransferDto payload)
    {
      await _transactionService.AddTransfer(payload, ((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
    }

    [HttpDelete("{id}")]
    public async Task Delete(long id)
    {
      await _transactionService.DeleteTransaction(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, id);
    }

    [HttpGet]
    public async Task<PageableCollection<TransactionModel>> Get(
      int skip,
      int take,
      string description,
      string transactionType,
      int? categoryType
    )
    {
      var data = await _transactionService.GetAll(
        ((ClaimsIdentity)User.Identity).FindFirst("Id").Value,
        skip,
        take,
        description,
        transactionType,
        categoryType
      );

      var count = await _transactionService.GetCount(
        ((ClaimsIdentity)User.Identity).FindFirst("Id").Value,
        description,
        transactionType,
        categoryType
      );

      return new PageableCollection<TransactionModel>()
      {
        Results = data,
        Total = count
      };
    }

    [HttpGet("heatmap")]
    public async Task<IEnumerable<TransactionActivityHeatmapModel>> GetHeatmap()
    {
      var data = await _transactionService.GetTransactionActivityHeatmap(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }
  }
}
