namespace fin_app_backend.Models
{
  public class AccountLatestValueModel
  {
    public int Id { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public string Currency { get; set; }
    public string Icon { get; set; }
  }
}