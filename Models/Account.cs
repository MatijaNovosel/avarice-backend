using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class AccountLatestValueModel : BaseModel
  {
    public double Amount { get; set; }
    public string Description { get; set; }
    public string Currency { get; set; }
    public string Icon { get; set; }
  }

  public class AccountTransactionModel : BaseModel
  {
    public string Description { get; set; }
  }
}