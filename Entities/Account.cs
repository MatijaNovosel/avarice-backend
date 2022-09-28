using System;
using System.Collections.Generic;
using avarice_backend.Entities.Base;

#nullable disable

namespace avarice_backend
{
  public partial class Account : EntityBase<long>
  {
    public Account()
    {
      Transactions = new HashSet<Transaction>();
      TransferTransactions = new HashSet<Transaction>();
      Templates = new HashSet<Template>();
    }
    public string Currency { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public string UserId { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<Template> Templates { get; set; }
    public virtual ICollection<Transaction> TransferTransactions { get; set; }
    public virtual ICollection<Template> TransferTemplates { get; set; }
  }
}
