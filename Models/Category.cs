using avarice_backend.Models.Base;

namespace avarice_backend.Models
{
  public class CategoryModel : BaseModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public CategoryModel Parent { get; set; }
  }

  public class CreateCategoryModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public long? ParentId { get; set; }
  }
}