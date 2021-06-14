using System;
using System.Collections.Generic;
using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class AddTransactionDto
  {
    public double Amount { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool? Expense { get; set; }
    public int? AccountId { get; set; }
    public List<int> TagIds { get; set; }
  }

  public class AddTransferDto
  {
    public double Amount { get; set; }
    public int AccountFromId { get; set; }
    public int AccountToId { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class TransactionModel : BaseModel
  {
    public double? Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Description { get; set; }
    public bool? Expense { get; set; }
    public string UserId { get; set; }
    public bool? Transfer { get; set; }
    public List<TagModel> Tags { get; set; }
    public AccountTransactionModel Account { get; set; }

  }
}