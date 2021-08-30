using fin_app_backend.Models.Base;
using System;

namespace fin_app_backend.Models
{
  public class AccountExpenseAndIncomeModel
  {
    public double Expense { get; set; }
    public double Income { get; set; }
  }

  public class AccountModel : BaseModel
  {
    public string Currency { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
  }

  public class AccountHistoryModel
  {
    public DateTime Date { get; set; }
    public double Amount { get; set; }
  }
}