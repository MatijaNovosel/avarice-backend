﻿using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;

#nullable disable

namespace fin_app_backend
{
  public partial class Category : Entity
  {
    public Category()
    {
      Transactions = new HashSet<Transaction>();
      Templates = new HashSet<Template>();
    }

    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public string UserId { get; set; }
    public bool System { get; set; }
    public long? ParentId { get; set; }
    public Category Parent { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<Template> Templates { get; set; }
    public ICollection<Category> SubCategories { get; set; }
  }
}
