using System;
using System.Collections.Generic;

namespace fin_app_backend.Models
{
  public class AddTransactionDto
  {
    public string UserId { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Expense { get; set; }
    public int AccountId { get; set; }
    public List<int> TagIds { get; set; }
  }

  public class AddTransferDto
  {
    public string UserId { get; set; }
    public double Amount { get; set; }
    public int AccountFromId { get; set; }
    public int AccountToId { get; set; }
  }
}