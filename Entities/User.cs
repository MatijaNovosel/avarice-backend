using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace fin_app_backend
{
  public partial class User : IdentityUser
  {
    public User()
    {
      Accounts = new HashSet<Account>();
      Histories = new HashSet<History>();
      Settings = new HashSet<Setting>();
      Tags = new HashSet<Tag>();
      Transactions = new HashSet<Transaction>();
    }

    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<History> Histories { get; set; }
    public virtual ICollection<Setting> Settings { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
  }
}
