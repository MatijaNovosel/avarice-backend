using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class CategoryModel : BaseModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
  }

  public class CreateCategoryModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
  }
}