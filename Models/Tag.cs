using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class TagModel : BaseModel
  {
    public int? UserId { get; set; }
    public string Description { get; set; }
  }
}