using System;
using System.Collections.Generic;
using avarice_backend.Entities.Base;

#nullable disable

namespace avarice_backend
{
  public partial class Transaction : EntityBase<long>
  {
    public Transaction()
    {
    }

    public double Amount { get; set; }
    public string Description { get; set; }
    public long AccountId { get; set; }
    public long? TransferAccountId { get; set; }
    public long CategoryId { get; set; }
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }
    public bool IsTransaction { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Account Account { get; set; }
    public virtual Account TransferAccount { get; set; }
    public virtual Category Category { get; set; }
  }
}
