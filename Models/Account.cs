using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class AccountLatestValueModel : BaseModel
  {
    public double Balance { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
  }

  public class AccountTransactionModel : BaseModel
  {
    public string Description { get; set; }
  }

  public class AccountModel : BaseModel
  {
    public string Description { get; set; }
  }
}