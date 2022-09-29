using System;
using System.Collections.Generic;
using avarice_backend.Entities.Base;

#nullable disable

namespace avarice_backend
{
  public partial class Template : EntityBase<long>
  {
    public Template()
    {
    }

    public double Amount { get; set; }
    public string Description { get; set; }
    public long AccountId { get; set; }
    public long? TransferAccountId { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; }
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Account Account { get; set; }
    public virtual Account TransferAccount { get; set; }
    public virtual Category Category { get; set; }
    public virtual User User { get; set; }
  }
}
