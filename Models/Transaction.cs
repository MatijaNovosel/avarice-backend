using System;
using System.Collections.Generic;
using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class AddTransactionDto
  {
    public double Amount { get; set; }
    public string Description { get; set; }
    public string TransactionType { get; set; }
    public long AccountId { get; set; }
    public long CategoryId { get; set; }
  }

  public class AddTransferDto
  {
    public double Amount { get; set; }
    public int AccountFromId { get; set; }
    public int AccountToId { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class TransactionCategoryModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
  }

  public class TransactionModel : BaseModel
  {
    public double? Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Description { get; set; }
    public string Currency { get; set; }
    public TransactionCategoryModel Category { get; set; }
    public string TransactionType { get; set; }
    public string Account { get; set; }
  }
}