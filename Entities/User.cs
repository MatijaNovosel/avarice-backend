using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace avarice_backend
{
  public partial class User : IdentityUser
  {
    public User()
    {
      Accounts = new HashSet<Account>();
      Transactions = new HashSet<Transaction>();
      Categories = new HashSet<Category>();
      Templates = new HashSet<Template>();
      Settings = new HashSet<Settings>();
    }

    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<Template> Templates { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Settings> Settings { get; set; }
  }
}
