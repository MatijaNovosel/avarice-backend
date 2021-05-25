using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;

#nullable disable

namespace fin_app_backend
{
    public partial class Setting : Entity
    {
        public bool? DarkMode { get; set; }
        public int? LocaleId { get; set; }
        public string PreferredCurrency { get; set; }
        public string DateFormat { get; set; }
        public int? UserId { get; set; }

        public virtual Locale Locale { get; set; }
        public virtual User User { get; set; }
    }
}
