using System;
using fin_app_backend.Models.Base;


namespace fin_app_backend
{
  public class HistoryTotalModel
  {
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class RecentDepositsAndWithdrawalsModel
  {
    public double Deposits { get; set; }
    public double Withdrawals { get; set; }
  }

  public class DailyChangeModel
  {
    public double Deposits { get; set; }
    public double Withdrawals { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class TagPercentageModel
  {
    public double Percentage { get; set; }
    public string Description { get; set; }
  }

  public class SpendingByTagModel
  {
    public double Amount { get; set; }
    public string Description { get; set; }
  }
}
