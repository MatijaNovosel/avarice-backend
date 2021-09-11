using System;
using System.Collections.Generic;
using fin_app_backend.Models.Base;

namespace fin_app_backend.Models
{
  public class AddTemplateDto
  {
    public double Amount { get; set; }
    public string Description { get; set; }
    public string TransactionType { get; set; }
    public long AccountId { get; set; }
    public long CategoryId { get; set; }
    public long? AccountToId { get; set; }
  }

  public class TemplateCategoryModel
  {
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public string ParentName { get; set; }
  }

  public class TemplateModel : BaseModel
  {
    public double? Amount { get; set; }
    public string Description { get; set; }
    public string Currency { get; set; }
    public TemplateCategoryModel Category { get; set; }
    public string TransactionType { get; set; }
    public string Account { get; set; }
  }
}