using System;
using System.Collections.Generic;
using avarice_backend.Models.Base;

namespace avarice_backend.Models
{
  public class AddTransactionDto
  {
    public double Amount { get; set; }
    public string Description { get; set; }
    public string TransactionType { get; set; }
    public long AccountId { get; set; }
    public long CategoryId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? SaveAsTemplate { get; set; }
  }

  public class AddTransferDto
  {
    public double Amount { get; set; }
    public long AccountFromId { get; set; }
    public long AccountToId { get; set; }
    public DateTime? CreatedAt { get; set; }
  }

  public class TransactionCategoryModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public string ParentName { get; set; }
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

  public class TransactionActivityHeatmapModel
  {
    public int Week { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }
    public string WeekDay { get; set; }
  }
}