using System;
using fin_app_backend.Models.Base;


namespace fin_app_backend
{
  public class HistoryModel : BaseModel
  {
    public int? AccountId { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UserId { get; set; }
  }

  public class HistoryTotalModel
  {
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
