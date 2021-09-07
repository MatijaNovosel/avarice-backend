using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;

#nullable disable

namespace fin_app_backend
{
  public partial class Transaction : Entity
  {
    public Transaction()
    {
    }

    public double? Amount { get; set; }
    public string Description { get; set; }
    public string TransactionType { get; set; }
    public long AccountId { get; set; }
    public long? TransferAccountId { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; }

    public virtual Account Account { get; set; }
    public virtual Account TransferAccount { get; set; }
    public virtual Category Category { get; set; }
    public virtual User User { get; set; }
  }
}
