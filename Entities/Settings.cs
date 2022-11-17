using System;
using System.Collections.Generic;
using avarice_backend.Entities.Base;

#nullable disable

namespace avarice_backend
{
  public partial class Settings : EntityBase<long>
  {
    public Settings() { }

    public string AccentColor { get; set; }
    public string UserId { get; set; }

    public virtual User User { get; set; }
  }
}
